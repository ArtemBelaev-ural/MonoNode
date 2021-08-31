using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/DestroyObject", 402)]
    public class DestroyObject : FlowNodeInOut
    {
        [Input]
        public GameObject Target;

        public override void Flow(NodePort flowPort)
        {
            var toDestroy = GetInputValue(nameof(Target), Target);
            Destroy(toDestroy);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
