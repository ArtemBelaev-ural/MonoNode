using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("String/" + nameof(ConcatString))]
    public class ConcatString : FlowNode
    {
        [Input] public string First;
        [Input] public string Second;
        [Output] public string Result;

        public override void ExecuteNode()
        {
            var first = GetInputValue(nameof(First), First);
            var second = GetInputValue(nameof(Second), Second);
            Result = $"{first}{second}";
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                return Result;
            }
            return null; // Replace this
        }
    }
}
