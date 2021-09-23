using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace XMonoNode
{
    /// <summary> Base class for all node graphs </summary>
    [Serializable]
    public class MonoNodeGraph : MonoBehaviour, INodeGraph, ISerializationCallbackReceiver
    {
        /// <summary> All nodes in the graph. <para/>
        /// See: <see cref="AddNode{T}"/> </summary>
        [SerializeField, HideInInspector] public MonoNode[] nodes = new MonoNode[0];

        public int NodesCount => nodes.Length;

        public INode[] GetNodes()
        {
            var result = new INode[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                result[i] = nodes[i];
            }
            return result;
        }

        /// <summary> Add a node to the graph by type </summary>
        public T AddNode<T>() where T : class, INode
        {
            return AddNode(typeof(T)) as T;
        }

        /// <summary> Placing it last in the nodes list </summary>
        public void MoveNodeToTop(INode node)
        {
            var castedNode = node as MonoNode;
            int index;
            while ((index = Array.IndexOf(nodes, castedNode)) != NodesCount - 1)
            {
                nodes[index] = nodes[index + 1];
                nodes[index + 1] = castedNode;
            }
        }

        /// <summary> Add a node to the graph by type </summary>
        public virtual INode AddNode(Type type)
        {
            MonoNode.graphHotfix = this;
            MonoNode node = gameObject.AddComponent(type) as MonoNode;
            node.OnNodeEnable();
            node.graph = this;
            var nodesList = new List<MonoNode>(nodes);
            nodesList.Add(node);
            nodes = nodesList.ToArray();
            return node;
        }

        /// <summary> Creates a copy of the original node in the graph </summary>
        public virtual INode CopyNode(INode original)
        {
            MonoNode originalNode = original as MonoNode;
            if(originalNode == null)
            {
                throw new ArgumentException("MonoNodeGraph can only copy MonoNodes");
            }

            MonoNode.graphHotfix = this;
            MonoNode node = gameObject.AddComponent(original.GetType()) as MonoNode;

            // Copy values
            FieldInfo[] fields =  node.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (field.Name != "ports")
                {
                    Debug.Log(field.Name);
                    field.SetValue(node, field.GetValue(originalNode));
                }
            }

            node.graph = this;
            node.ClearConnections();
            var nodesList = new List<MonoNode>(nodes);
            nodesList.Add(node);
            nodes = nodesList.ToArray();
            return node;
        }

        /// <summary> Safely remove a node and all its connections </summary>
        /// <param name="node"> The node to remove </param>
        public void RemoveNode(INode node)
        {
            node.ClearConnections();
            var nodesList = new List<MonoNode>(nodes);
            nodesList.Remove(node as MonoNode);
            nodes = nodesList.ToArray();
            if (Application.isPlaying) DestroyImmediate(node as UnityEngine.Object);
        }

        /// <summary> Remove all nodes and connections from the graph </summary>
        public void Clear()
        {
            //if (Application.isPlaying)
            //{
            //    foreach (MonoNode node in nodes)
            //    {
            //        if (nodes != null)
            //        {
            //            Destroy(node);
            //        }
            //    }
            //}
            nodes = new MonoNode[0];
        }

        /// <summary> Create a new deep copy of this graph </summary>
        public XMonoNode.INodeGraph Copy()
        {
            // Instantiate a new nodegraph instance
            MonoNodeGraph graph = Instantiate(this);
            return graph;
        }

        private void OnDestroy()
        {
            // Remove all nodes prior to graph destruction
            Clear();
        }

        public void OnBeforeSerialize()
        {
            try // GetComponents() causes NullreferenceException in reset()
            {
                nodes = GetComponents<MonoNode>();
            }
            catch {}

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].OnNodeEnable();
                nodes[i].graph = this;
            }
        }

        public void OnAfterDeserialize()
        {
        }

        public System.Type getNodeType()
        {
            return typeof(MonoNode);
        }
    }
}
