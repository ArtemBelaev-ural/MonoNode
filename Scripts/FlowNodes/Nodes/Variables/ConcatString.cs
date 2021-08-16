using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("String/" + nameof(ConcatString))]
    public class ConcatString : MonoNode
    {
        [Input] public string First;
        [Input] public string Second;
        [Output] public string Result;


        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                var first = GetInputValue(nameof(First), First as object);
                var second = GetInputValue(nameof(Second), Second as object);
                Result = $"{first}{second}";

                return Result;
            }
            return null; // Replace this
        }
    }
}
