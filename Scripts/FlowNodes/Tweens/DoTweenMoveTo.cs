#if DOTWEEN_SUPPORTED
using DG.Tweening;
using UnityEngine;
using XNode;

namespace FlowNodes
{
    [CreateNodeMenu("Animation/Tween/MoveTo")]
    public class DoTweenMoveTo : BaseDoTween
    {
        [Input] public GameObject Target;
        [Input] public Vector3 TargetValue;

        public override void ExecuteNode()
        {
            StartTween(GetInputValue(nameof(TargetValue), TargetValue));
        }

        public void StartTween(Vector3 targetValue)
        {
            if (tween == null)
            {
                var target = GetInputValue(nameof(Target), Target);
                var duration = GetInputValue(nameof(Duration), Duration);
                tween = target.transform.DOMove(targetValue, duration);
                SetupTween(tween);
            }
        }
    }
}
#endif

