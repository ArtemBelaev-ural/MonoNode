using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Logic/Not", 102)]
    public class Not : MonoNode {
        [Input] public bool Input;
        [Output] public bool Result;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                return !GetInputValue<bool>(nameof(Input), Input);
            }
            return null; // Replace this
        }
    }
}