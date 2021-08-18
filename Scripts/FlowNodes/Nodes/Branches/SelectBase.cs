using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMonoNode
{
    public abstract class SelectBase: MonoNode
    {
        [Inline]
        [Input(connectionType: ConnectionType.Override)]
        public bool condition;

        public abstract System.Type Type
        {
            get;
        }
    }

    public abstract class SelectNode<T> : SelectBase
    {
        [Output] public T output;

        [Input(connectionType: ConnectionType.Override)]
        public T inputTrue;

        [Input(connectionType: ConnectionType.Override)]
        public T inputFalse;

        public override System.Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        public override void OnNodeEnable()
        {
            base.OnNodeEnable();
            // Для удобства изменим подпись к стандартным flow портам

            NodePort portTrue = GetInputPort(nameof(inputTrue));
            if (portTrue != null)
            {
                portTrue.label = "True";
            }
            NodePort portFalse = GetInputPort(nameof(inputFalse));
            if (portFalse != null)
            {
                portFalse.label = "False";
            }
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(output))
            {
                condition = GetInputValue(nameof(condition), condition);
                return condition ? GetInputValue<object>(nameof(inputTrue), inputTrue) : GetInputValue<object>(nameof(inputFalse), inputFalse);
            }
            return null;
        }
    }
}
