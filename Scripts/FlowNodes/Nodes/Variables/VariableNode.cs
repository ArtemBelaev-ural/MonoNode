using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XMonoNode
{
    public abstract class VariableNode : MonoNode
    {
        public abstract System.Type Type
        {
            get;
        }
    }

    [NodeWidth(200)]
    public abstract class VariableNode<T> : VariableNode
    {
        [Input]
        public T inputValue = default(T);

        [Output]
        public T output = default(T);

        public override System.Type Type => typeof(T);

        private void Reset()
        {
            Name = "Variable: " + typeof(T).Name;
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(output))
            {
                return GetInputValue(nameof(inputValue), inputValue);
            }
            else return null;
        }

    }
}



