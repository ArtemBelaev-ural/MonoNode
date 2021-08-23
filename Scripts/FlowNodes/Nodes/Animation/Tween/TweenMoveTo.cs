#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Animation/Tween/MoveTo", 101)]
    public class TweenMoveTo : TweenTransform
    {

        private void Reset()
        {
            Name = "MoveTo";
        }

        protected override Vector3 GetStartValue()
        {
            if (target == null)
            {
                return Vector3.zero;
                
            }

            return target.transform.localPosition;
        }

        protected override void SetValue(Vector3 value)
        {
            if (target == null)
            {
                return;

            }

            target.transform.localPosition = value;
        }
    }
}
#endif
