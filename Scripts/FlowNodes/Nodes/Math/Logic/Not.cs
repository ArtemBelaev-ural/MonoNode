using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Logic/Not", 102)]
    [NodeWidth(110)]
    public class Not : MonoNode
    {
        [Input(connectionType: ConnectionType.Override, backingValue: ShowBackingValue.Never, typeConstraint: TypeConstraint.Inherited), Inline]
        public bool Input;

        [Output]
        public bool Result;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                return !GetInputValue(nameof(Input), Input);
            }
            return null; // Replace this
        }
    }
}