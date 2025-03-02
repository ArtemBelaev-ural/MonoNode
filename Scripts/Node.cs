﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace XMonoNode {
    /// <summary>
    /// Base class for all nodes
    /// </summary>
    /// <example>
    /// Classes extending this class will be considered as valid nodes by xNode.
    /// <code>
    /// [System.Serializable]
    /// public class Adder : Node {
    ///     [Input] public float a;
    ///     [Input] public float b;
    ///     [Output] public float result;
    ///
    ///     // GetValue should be overridden to return a value for any specified output port
    ///     public override object GetValue(NodePort port) {
    ///         return a + b;
    ///     }
    /// }
    /// </code>
    /// </example>
    [Serializable]
    public abstract class Node : ScriptableObject, INode
    {
        #region Obsolete
        [Obsolete("Use DynamicPorts instead")]
        public IEnumerable<NodePort> InstancePorts
        {
            get
            {
                return DynamicPorts;
            }
        }

        [Obsolete("Use DynamicOutputs instead")]
        public IEnumerable<NodePort> InstanceOutputs
        {
            get
            {
                return DynamicOutputs;
            }
        }

        [Obsolete("Use DynamicInputs instead")]
        public IEnumerable<NodePort> InstanceInputs
        {
            get
            {
                return DynamicInputs;
            }
        }

        [Obsolete("Use AddDynamicInput instead")]
        public NodePort AddInstanceInput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
        {
            return AddDynamicInput(type, connectionType, typeConstraint, fieldName);
        }

        [Obsolete("Use AddDynamicOutput instead")]
        public NodePort AddInstanceOutput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
        {
            return AddDynamicOutput(type, connectionType, typeConstraint, fieldName);
        }

        [Obsolete("Use AddDynamicPort instead")]
        private NodePort AddInstancePort(Type type, NodePort.IO direction, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
        {
            return AddDynamicPort(type, direction, connectionType, typeConstraint, fieldName);
        }

        [Obsolete("Use RemoveDynamicPort instead")]
        public void RemoveInstancePort(string fieldName)
        {
            RemoveDynamicPort(fieldName);
        }

        [Obsolete("Use RemoveDynamicPort instead")]
        public void RemoveInstancePort(NodePort port)
        {
            RemoveDynamicPort(port);
        }

        [Obsolete("Use ClearDynamicPorts instead")]
        public void ClearInstancePorts()
        {
            ClearDynamicPorts();
        }
        #endregion

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        /// <summary> Iterate over all ports on this node. </summary>
        public IEnumerable<NodePort> Ports
        {
            get
            {
                foreach (NodePort port in ports.Values)
                    yield return port;
            }
        }
        /// <summary> Iterate over all outputs on this node. </summary>
        public IEnumerable<NodePort> Outputs
        {
            get
            {
                foreach (NodePort port in Ports)
                {
                    if (port.IsOutput)
                        yield return port;
                }
            }
        }
        /// <summary> Iterate over all inputs on this node. </summary>
        public IEnumerable<NodePort> Inputs
        {
            get
            {
                foreach (NodePort port in Ports)
                {
                    if (port.IsInput)
                        yield return port;
                }
            }
        }
        /// <summary> Iterate over all dynamic ports on this node. </summary>
        public IEnumerable<NodePort> DynamicPorts
        {
            get
            {
                foreach (NodePort port in Ports)
                {
                    if (port.IsDynamic)
                        yield return port;
                }
            }
        }
        /// <summary> Iterate over all dynamic outputs on this node. </summary>
        public IEnumerable<NodePort> DynamicOutputs
        {
            get
            {
                foreach (NodePort port in Ports)
                {
                    if (port.IsDynamic && port.IsOutput)
                        yield return port;
                }
            }
        }
        /// <summary> Iterate over all dynamic inputs on this node. </summary>
        public IEnumerable<NodePort> DynamicInputs
        {
            get
            {
                foreach (NodePort port in Ports)
                {
                    if (port.IsDynamic && port.IsInput)
                        yield return port;
                }
            }
        }
        /// <summary> Parent <see cref="NodeGraph"/> </summary>
        [SerializeField] public NodeGraph graph;
        /// <summary> Position on the <see cref="NodeGraph"/> </summary>
        [SerializeField] public Vector2 position;
        /// <summary>
        /// Is the node's advanced ports and other controls is hidden
        /// </summary>
        [SerializeField, HideInNodeInspector] public INode.ShowAttribState showState = INode.ShowAttribState.ShowBase;
        /// <summary> It is recommended not to modify these at hand. Instead, see <see cref="InputAttribute"/> and <see cref="OutputAttribute"/> </summary>
        [SerializeField] private NodePortDictionary ports = new NodePortDictionary();

        /// <summary> Used during node instantiation to fix null/misconfigured graph during OnEnable/Init. Set it before instantiating a node. Will automatically be unset during OnEnable </summary>
        public static NodeGraph graphHotfix;
        public INodeGraph Graph
        {
            get
            {
                return graph;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public INode.ShowAttribState ShowState
        {
            get => showState;
            set => showState = value;
        }

        protected void OnEnable()
        {
            if (graphHotfix != null)
                graph = graphHotfix;
            graphHotfix = null;
            UpdatePorts();
            Init();
        }

        /// <summary> Update static ports and dynamic ports managed by DynamicPortLists to reflect class fields. This happens automatically on enable or on redrawing a dynamic port list. </summary>
        public void UpdatePorts()
        {
            NodeDataCache.UpdatePorts(this, ports);
        }

        /// <summary> Initialize node. Called on enable. </summary>
        protected virtual void Init()
        {
        }

        /// <summary> Checks all connections for invalid references, and removes them. </summary>
        public void VerifyConnections()
        {
            foreach (NodePort port in Ports)
                port.VerifyConnections();
        }

        #region Dynamic Ports
        /// <summary> Convenience function. </summary>
        /// <seealso cref="AddInstancePort"/>
        /// <seealso cref="AddInstanceOutput"/>
        public NodePort AddDynamicInput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
        {
            return AddDynamicPort(type, NodePort.IO.Input, connectionType, typeConstraint, fieldName);
        }

        /// <summary> Convenience function. </summary>
        /// <seealso cref="AddInstancePort"/>
        /// <seealso cref="AddInstanceInput"/>
        public NodePort AddDynamicOutput(Type type, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
        {
            return AddDynamicPort(type, NodePort.IO.Output, connectionType, typeConstraint, fieldName);
        }

        /// <summary> Add a dynamic, serialized port to this node. </summary>
        /// <seealso cref="AddDynamicInput"/>
        /// <seealso cref="AddDynamicOutput"/>
        private NodePort AddDynamicPort(Type type, NodePort.IO direction, ConnectionType connectionType = ConnectionType.Multiple, TypeConstraint typeConstraint = TypeConstraint.None, string fieldName = null)
        {
            if (fieldName == null)
            {
                fieldName = "dynamicInput_0";
                int i = 0;
                while (HasPort(fieldName))
                    fieldName = "dynamicInput_" + (++i);
            }
            else if (HasPort(fieldName))
            {
                Debug.LogWarning("Port '" + fieldName + "' already exists in " + name, this);
                return ports[fieldName];
            }
            NodePort port = new NodePort(fieldName, type, direction, connectionType, typeConstraint, this);
            ports.Add(fieldName, port);
            return port;
        }

        /// <summary> Remove an dynamic port from the node </summary>
        public void RemoveDynamicPort(string fieldName)
        {
            NodePort dynamicPort = GetPort(fieldName);
            if (dynamicPort == null)
                throw new ArgumentException("port " + fieldName + " doesn't exist");
            RemoveDynamicPort(GetPort(fieldName));
        }

        /// <summary> Remove an dynamic port from the node </summary>
        public void RemoveDynamicPort(NodePort port)
        {
            if (port == null)
                throw new ArgumentNullException("port");
            else if (port.IsStatic)
                throw new ArgumentException("cannot remove static port");
            port.ClearConnections();
            ports.Remove(port.fieldName);
        }

        /// <summary> Removes all dynamic ports from the node </summary>
        [ContextMenu("Clear Dynamic Ports")]
        public void ClearDynamicPorts()
        {
            List<NodePort> dynamicPorts = new List<NodePort>(DynamicPorts);
            foreach (NodePort port in dynamicPorts)
            {
                RemoveDynamicPort(port);
            }
        }
        #endregion

        #region Ports
        /// <summary> Returns output port which matches fieldName </summary>
        public NodePort GetOutputPort(string fieldName)
        {
            NodePort port = GetPort(fieldName);
            if (port == null || port.direction != NodePort.IO.Output)
                return null;
            else
                return port;
        }

        /// <summary> Returns input port which matches fieldName </summary>
        public NodePort GetInputPort(string fieldName)
        {
            NodePort port = GetPort(fieldName);
            if (port == null || port.direction != NodePort.IO.Input)
                return null;
            else
                return port;
        }

        /// <summary> Returns port which matches fieldName </summary>
        public NodePort GetPort(string fieldName)
        {
            NodePort port;
            if (ports.TryGetValue(fieldName, out port))
                return port;
            else
                return null;
        }

        public bool HasPort(string fieldName)
        {
            return ports.ContainsKey(fieldName);
        }
        #endregion

        #region Inputs/Outputs
        /// <summary> Return input value for a specified port. Returns fallback value if no ports are connected </summary>
        /// <param name="fieldName">Field name of requested input port</param>
        /// <param name="fallback">If no ports are connected, this value will be returned</param>
        public T GetInputValue<T>(string fieldName, T fallback = default(T))
        {
            NodePort port = GetPort(fieldName);
            if (port != null && port.IsConnected)
                return port.GetInputValue<T>();
            else
                return fallback;
        }

        /// <summary> Return all input values for a specified port. Returns fallback value if no ports are connected </summary>
        /// <param name="fieldName">Field name of requested input port</param>
        /// <param name="fallback">If no ports are connected, this value will be returned</param>
        public T[] GetInputValues<T>(string fieldName, params T[] fallback)
        {
            NodePort port = GetPort(fieldName);
            if (port != null && port.IsConnected)
                return port.GetInputValues<T>();
            else
                return fallback;
        }

        /// <summary> Returns a value based on requested port output. Should be overridden in all derived nodes with outputs. </summary>
        /// <param name="port">The requested port.</param>
        public virtual object GetValue(NodePort port)
        {
            Debug.LogWarning("No GetValue(NodePort port) override defined for " + GetType());
            return null;
        }
        #endregion

        /// <summary> Called after a connection between two <see cref="NodePort"/>s is created </summary>
        /// <param name="from">Output</param> <param name="to">Input</param>
        public virtual void OnCreateConnection(NodePort from, NodePort to)
        {
        }

        /// <summary> Called after a connection is removed from this port </summary>
        /// <param name="port">Output or Input</param>
        public virtual void OnRemoveConnection(NodePort port)
        {
        }

        /// <summary> Disconnect everything from this node </summary>
        public void ClearConnections()
        {
            foreach (NodePort port in Ports)
                port.ClearConnections();
        }
    }
}
