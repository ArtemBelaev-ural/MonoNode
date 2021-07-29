using System;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// A convenient graph for use with flow nodes
    /// </summary>
    [AddComponentMenu("Flow Nodes/FlowNodeGraph", 1)]
    [ExecuteInEditMode]
    public class FlowNodeGraph : MonoNodeGraph
    {
        /// <summary>
        /// Параметры, передаваемые в метод XSoundNodeGraph.Play() или XSoundNodePlay.Play()
        /// </summary>
        public object[] ExecuteParameters
        {
            get
            {
                if (executeParameters == null)
                {
                    executeParameters = new object[0];
                }
                return executeParameters;
            }
            set
            {
                if (executeParameters != value)
                {
                    executeParameters = value;
                }
            }

        }

        private object[]     executeParameters = new object[0];
        [SerializeField, HideInInspector]
        public string NodeToTestExecute = "-";

        [ContextMenu("Execute")]
        public void TestExecute()
        {
            UpdateTestParameters();

            Execute(NodeToTestExecute, executeParameters);
        }

        public virtual void UpdateParameters(params object[] parameters)
        {
            ExecuteParameters = parameters;
        }

        /// <summary>
        /// Обновляет значения параметров в режиме редактора. Значения берет из нодов параметров (синего цвета)
        /// </summary>

        public virtual void UpdateTestParameters()
        {
            ExecuteParameter[] paramNodes = GetComponents<ExecuteParameter>();
            ExecuteParameters = new object[paramNodes.Length];

            for (int i = 0; i < paramNodes.Length; ++i)
            {
                ExecuteParameters[i] = paramNodes[i].GetTestValue();
            }
        }

        private bool hasNodeWithName(FlowNode[] flowNodes, string name)
        {
            foreach (var play in flowNodes)
            {
                if (play.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public const string ALL_NODES = ":- all nodes";

        public void Execute(params object[] parameters)
        {
            Execute(null, parameters);
        }

        /// <summary>
        /// Plays sound graph
        /// </summary>
        /// <param name="flowNodeName">Name of node wich will execute. If empty all nodes will playing. If there is no such name, all nodes are played. </param>
        /// <param name="parameters">Custom graph parameters<seealso cref="ExecuteParameter"/></param>
        public void Execute(string flowNodeName = null, params object[] parameters)
        {
            if (flowNodeName == null)
            {
                flowNodeName = NodeToTestExecute;
            }

            UpdateParameters(parameters);
            FlowNode[] flowNodes = GetComponents<FlowNode>();
            if (flowNodes.Length == 0)
            {
                Debug.LogError(gameObject.name + ": FlowNodeGraph hasn't FlowNode");
            }

            if (flowNodeName != ALL_NODES && !hasNodeWithName(flowNodes, flowNodeName)) 
            {
                Debug.LogError(gameObject.name + ": there is no node named \"" +flowNodeName+"\" in the graph");
            }

            foreach (var node in flowNodes)
            {
                if (flowNodeName == ALL_NODES ||
                    node.Name.Equals(flowNodeName, StringComparison.OrdinalIgnoreCase))
                {
                    node.ExecuteNode();
                }
            }
        }

        [ContextMenu("Stop")]
        public virtual void Stop()
        {
            FlowNode[] nodes = GetComponents<FlowNode>();

            foreach (var node in nodes)
            {
                node.Stop();
            }
        }
    }


    public static class ExtensionMethods
    {
        public static T RandomElement<T>(this List<T> parameters, int startIndex = 0)
        {
            int count=parameters.Count;
            if (parameters == null || count == 0)
            {
                return default;
            }

            return parameters[UnityEngine.Random.Range(Mathf.Min(count - 1, startIndex), count)];
        }

        public static T RandomElement<T>(this T[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                return default(T);
            }
            return (T)parameters[UnityEngine.Random.Range(0, parameters.Length)];
        }

        public static string ToHex(this Color color)
        {
            string rtn = "#" + ((int)(color.r * 255)).ToString("X2") + ((int)(color.g * 255)).ToString("X2") + ((int)(color.b * 255)).ToString("X2");
            return rtn;
        }

        public static string Color(this string need, Color color)
        {
            return "<color=" + color.ToHex() + ">" + need + "</color>";
        }

        public static string Color(this string need, string color)
        {
            return "<color=" + color + ">" + need + "</color>";
        }

        public static T Get<T>(this object[] parameters, int index = 0)
        {
            T result = default(T);
            int currentIndex = -1;
            Type targetType = typeof(T);
#if NETFX_CORE
            TypeInfo targetTypeInfo = targetType.GetTypeInfo();
#else
            Type targetTypeInfo = targetType;
#endif
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == null)
                {
                    continue;
                }
#if NETFX_CORE
                TypeInfo type = parameters[i].GetType().GetTypeInfo();
#else
                Type type = parameters[i].GetType();
#endif
                if (targetTypeInfo.IsAssignableFrom(type) ||
                    type.IsAssignableFrom(targetTypeInfo) ||
                    type.IsSubclassOf(targetType))
                {
                    currentIndex++;
                    if (currentIndex == index)
                    {
                        result = (T)parameters[i];
                        break;
                    }
                }
            }
            return result;
        }
    }
}