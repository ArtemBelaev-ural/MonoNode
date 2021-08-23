using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Logic/AndOr", 101)]
    public class AndOr : MonoNode {
        public enum Operation {
            And,
            Or,
        }

        [Input] public bool InputA;
        [Input] public bool InputB;
        public Operation MyOperation;
        [Output] public bool Result;

        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Result)) {
                var a = GetInputValue<bool>(nameof(InputA), InputA);
                var b = GetInputValue<bool>(nameof(InputB), InputB);
                return MyOperation == Operation.And ? a && b : a || b;
            }
            return null; // Replace this
        }
    }
}
