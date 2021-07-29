using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    public abstract class ExecuteParameter : MonoNode
    {
        /// <summary>
        /// «начение параметра
        /// </summary>
        public abstract object GetTestValue();
    }

    /// <summary>
    /// ¬озвращает параметр, переданный в метод XSoundNodeGraph.Play()
    /// </summary>
    [NodeTint(50, 70, 105)]
    [NodeWidth(220)]
    public abstract class ExecuteParameter<T> : ExecuteParameter
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
            Name = "PlayParam: " + typeof(T).Name;
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(output))
            {
                FlowNodeGraph flowGraph = graph as FlowNodeGraph;
                if (flowGraph != null)
                {
                    return flowGraph.ExecuteParameters.Get<T>();
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
