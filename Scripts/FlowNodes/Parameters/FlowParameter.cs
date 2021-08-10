using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    public abstract class FlowParameter : MonoNode
    {
        /// <summary>
        /// «начение параметра
        /// </summary>
        public abstract object GetTestValue();
    }

    /// <summary>
    /// ¬озвращает параметр, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [NodeTint(50, 70, 105)]
    [NodeWidth(200)]
    public abstract class FlowParameter<T> : FlowParameter
    {
        [Output] public T   output;

        [SerializeField, HideInInspector]
        private T           testValue = default(T);

        /// <summary>
        /// «начение, используемое дл€ тестировани€ в редакторе
        /// </summary>
        public T TestValue
        {
            get => testValue;
            set
            {
                testValue = value;
            }
        }

        private void Reset()
        {
            Name = "Parameter: " + typeof(T).Name;
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(output))
            {
                FlowNodeGraph flowGraph = graph as FlowNodeGraph;
                if (flowGraph != null)
                {
                    if (flowGraph.FlowParametersDict.TryGetValue(Name, out object value))
                    {
                        return value;
                    }
                    else
                    {
                        return flowGraph.FlowParametersArray.Get<T>();
                    }
                }
            }
            return null;
        }

        public override object GetTestValue()
        {
            return testValue;
        }
    }
}
