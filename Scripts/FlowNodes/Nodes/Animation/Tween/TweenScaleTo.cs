#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Animation/Tween/ScaleTo", 103)]
    public class TweenScaleTo : TweenTransform
    {
        private void Reset()
        {
            Name = "ScaleTo";
        }

        protected override Vector3 GetStartValue()
        {
            if (target == null)
            {
                return Vector3.one;
                
            }

            return target.transform.localScale;
        }

        protected override void SetValue(Vector3 value)
        {
            if (target == null)
            {
                return;

            }

            target.transform.localScale = value;
        }
    }
}
#endif
