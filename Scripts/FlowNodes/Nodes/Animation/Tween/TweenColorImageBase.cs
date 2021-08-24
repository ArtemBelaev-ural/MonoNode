#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    public abstract class TweenColorImageBase : TweenObjectValue<UnityEngine.UI.Image, Color>
    {
        protected override void OnTweenTick(float tNormal)
        {
            if (target == null)
            {
                return;
            }
            SetValue(Color.LerpUnclamped(startValue, targetValue, tNormal));
        }

        protected override void OnNextLoop(LoopType loopType)
        {

            if (loopType == LoopType.Incremental)
            {
                Color delta = targetValue - startValue;
                startValue += delta;
                targetValue += delta;
            }
        }
    }
}
#endif
