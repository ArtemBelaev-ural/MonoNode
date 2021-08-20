using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Animation/"+nameof(PlayAnimation), 1)]
    public class PlayAnimation : FlowNodeInOut 
    {
        [Input] public Animator Target;
        [Input] public string StateName;

        public override void Flow(NodePort flowPort) 
        {
            var animator = GetInputValue(nameof(Target), Target);
            var stateName = GetInputValue(nameof(StateName), StateName);
            animator.Play(stateName);
        }

        public override object GetValue(NodePort port) 
        {
            return null;
        }
    }
}
