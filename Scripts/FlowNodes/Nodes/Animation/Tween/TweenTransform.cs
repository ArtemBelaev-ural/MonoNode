#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    public abstract class TweenTransform: TweenNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public GameObject target;

        [Input(connectionType: ConnectionType.Override)]
        public Vector3 targetValue;

        protected Vector3 startValue;

        protected abstract Vector3 GetStartValue();

        protected abstract void SetValue(Vector3 value);

        protected override void OnTweenStart()
        {
            target = GetInputValue(nameof(target), target);
            startValue = GetStartValue();
            targetValue = GetInputValue(nameof(targetValue), targetValue);
        }

        protected override void OnTweenTick(float tNormal)
        {
            SetValue(startValue + (targetValue - startValue) * tNormal);
        }

        protected override void OnTweenEnd()
        {

        }

        protected override void OnNextLoop(LoopType loopType)
        {
            if (loopType == LoopType.Incremental)
            {

                Vector3 delta = targetValue - startValue;
                startValue += delta;
                targetValue += delta;
            }
        }
    }
}
#endif
