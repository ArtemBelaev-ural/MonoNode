using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    public abstract class InputFlowParameter : MonoNode
    {
        /// <summary>
        /// Значение параметра
        /// </summary>
        public abstract object GetDefaultValue();
    }

    /// <summary>
    /// Возвращает параметр, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [NodeTint(50, 70, 105)]
    [NodeWidth(200)]
    public abstract class InputFlowParameter<T> : InputFlowParameter
    {
        [SerializeField]
        public int index = -1;

        [Output(backingValue: ShowBackingValue.Always), HideLabel] public T   output;

        

        /// <summary>
        /// Значение, используемое по умолчанию
        /// </summary>
        public T DefaultValue
        {
            get => output;
            set => output = value;
        }

        protected override void Init()
        {
            base.Init();

            GetOutputPort(nameof(output)).label = "Default";
        }

        private void Reset()
        {
            Name = "Input Param: " + NodeUtilities.PrettyName(typeof(T));
        }

        public override object GetValue(NodePort port)
        {
            FlowNodeGraph flowGraph = graph as FlowNodeGraph;
            if (flowGraph != null)
            {
                if (index > -1)
                {
                    if (index < flowGraph.FlowParametersArray.Length)
                    {
                        return flowGraph.FlowParametersArray[index];
                    }
                    else
                    {
                        Debug.LogErrorFormat("{0}.{1} Input parameter index out of bounds {2}", graph.gameObject.name, Name, index);
                    }
                }
                if (flowGraph.OutputFlowParametersDict.TryGetValue(Name, out object value))
                {
                    return value;
                }
                else
                {
                    
                    value = flowGraph.FlowParametersArray.Get<T>(output);
                    return value;//return (typeof(T).IsValueType || !Equals(value, default(T))) ? value : output;
                }
            }
  
            return output;
        }

        public override object GetDefaultValue()
        {
            return output;
        }
    }
}
