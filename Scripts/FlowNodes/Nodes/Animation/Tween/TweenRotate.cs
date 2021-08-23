#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Animation/Tween/Rotate", 102)]
    public class TweenRotate : TweenTransform
    {
        private void Reset()
        {
            Name = "Rotate";
        }

        protected override void OnTweenTick(float tNormal)
        {
            Vector3 value = new Vector3(
                Mathf.LerpAngle(startValue.x, targetValue.x, tNormal),
                Mathf.LerpAngle(startValue.y, targetValue.y, tNormal),
                Mathf.LerpAngle(startValue.z, targetValue.z, tNormal));

            target.transform.localEulerAngles = value;
        }

        protected override Vector3 GetStartValue()
        {
            if (target == null)
            {
                return Vector3.one;
                
            }

            return target.transform.localRotation.eulerAngles;
        }

        protected override void SetValue(Vector3 value)
        {
            if (target == null)
            {
                return;
            }

            target.transform.localEulerAngles = value;
        }
    }
}
#endif
