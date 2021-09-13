using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Logic/AndOr", 101)]
    [NodeWidth(180)]
    public class AndOr : MonoNode
    {
        public enum Operation
        {
            And,
            Or,
        }

        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited), Inline]
        public bool InputA;

        [Output] public bool Result;

        [Input(connectionType: ConnectionType.Override)]
        public bool InputB;

        public Operation MyOperation;


        public override object GetValue(NodePort port)
        {
            var a = GetInputValue<bool>(nameof(InputA), InputA);
            var b = GetInputValue<bool>(nameof(InputB), InputB);
            return MyOperation == Operation.And ? a && b : a || b;
        }
    }
}
