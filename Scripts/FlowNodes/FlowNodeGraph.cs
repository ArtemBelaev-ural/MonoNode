using System;
using System.Collections;
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
    [RequireComponent(typeof(OnFlowEventNode))]
    [RequireNode(typeof(OnFlowEventNode))]
    public class FlowNodeGraph : MonoNodeGraph
    {
        /// <summary>
        /// Параметры, передаваемые в метод FlowNodeGraph.Flow()
        /// </summary>
        public object[] FlowParametersArray
        {
            get
            {
                return flowParametersArray;
            }
            set
            {
                if (flowParametersArray != value)
                {
                    flowParametersArray = value;
                    FlowParametersDict.Clear();
                }
            }

        }

        private object[]     flowParametersArray = new object[0];

        /// <summary>
        /// Параметры, передаваемые в метод FlowNodeGraph.Flow()
        /// </summary>
        public Dictionary<string, object> FlowParametersDict
        {
            get => flowParametersDict;
            private set
            {
                flowParametersDict = value;
                flowParametersArray = new object[value.Count];
                int i = 0;
                foreach (var pair in value)
                {
                    flowParametersArray[i] = pair.Value;
                    ++i;
                }
            }
        }

        private Dictionary<string, object> flowParametersDict = new Dictionary<string, object>();

        private void OnUpdateParametersNodes()
        {
            OnUpdateParametersNode[] nodes = GetComponents<OnUpdateParametersNode>();
 
            foreach (var node in nodes)
            {
                node.TriggerFlow();
            }
        }

        public virtual void UpdateParameters(params object[] parameters)
        {
            FlowParametersArray = parameters;
            OnUpdateParametersNodes();
        }

        private static Dictionary<TKey, TValue> Merge<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (var dict in dictionaries)
                foreach (var x in dict)
                    result[x.Key] = x.Value;
            return result;
        }

        public virtual void UpdateParameters(Dictionary<string, object> parameters)
        {
            FlowParametersDict = parameters;
            OnUpdateParametersNodes();
        }

        public virtual void UpdateParameter(string key, object value)
        {
            flowParametersDict[key] = value;
        }

        /// <summary>
        /// Обновляет значения параметров в режиме редактора. Значения берет из нодов параметров (синего цвета)
        /// </summary>

        public virtual void UpdateTestParameters()
        {
            FlowParameter[] paramNodes = GetComponents<FlowParameter>();
            FlowParametersArray = new object[paramNodes.Length];

            for (int i = 0; i < paramNodes.Length; ++i)
            {
                FlowParametersArray[i] = paramNodes[i].GetTestValue();
            }
            OnUpdateParametersNodes();
        }

        public const string ALL_EXECUTE_NODES = ":- all execute nodes";

        /// <summary>
        /// Starts flow of the graph
        /// </summary>
        /// <param name="parameters">Custom graph parameters<seealso cref="FlowParameter"/></param>
        public virtual void Flow(params object[] parameters)
        {
            UpdateParameters(parameters);
            Flow();
        }

        /// <summary>
        /// Starts flow of the graph
        /// </summary>
        /// <param name="parameters">Custom graph parameters<seealso cref="FlowParameter"/></param>
        public virtual void Flow(Dictionary<string, object> parameters)
        {
            UpdateParameters(parameters);
            Flow();
        }

        [ContextMenu("Flow")]
        public virtual void Flow()
        {
            OnFlowEventNode[] eventNodes = GetComponents<OnFlowEventNode>();
            if (eventNodes.Length == 0)
            {
                Debug.LogError(gameObject.name + ": FlowNodeGraph hasn't OnExecute nodes");
            }

            foreach (var node in eventNodes)
            {
                node.TriggerFlow();
            }
        }

        [ContextMenu("Stop")]
        public virtual void Stop()
        {
            IFlowNode[] nodes = GetComponents<IFlowNode>();

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