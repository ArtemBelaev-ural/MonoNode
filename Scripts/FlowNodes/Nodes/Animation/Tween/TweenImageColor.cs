#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Animation/Tween/ImageColor", 117)]
    public class TweenImageColor : TweenColorImageBase
    {
        private void Reset()
        {
            Name = "Image Color";
        }

        protected override Color GetStartValue()
        {
            return target.color;
        }

        protected override void SetValue(Color value)
        {
            target.color = value;
        }
    }
}
#endif
