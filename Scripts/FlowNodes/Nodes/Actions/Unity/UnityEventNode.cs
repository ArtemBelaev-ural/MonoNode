using UnityEngine.Events;
using XMonoNode;

namespace XMonoNode
{
    [NodeWidth(400)]
    [CreateNodeMenu("Events/" + nameof(UnityEventNode), 14)]
    public class UnityEventNode : FlowNode
    {
        public UnityEvent Target;

        public override void ExecuteNode()
        {
            Target.Invoke();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}
