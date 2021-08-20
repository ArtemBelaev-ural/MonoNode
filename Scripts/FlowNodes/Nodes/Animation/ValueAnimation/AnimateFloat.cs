using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Animation/AnimateValue/Float")]
    [NodeWidth(170)]
    public class AnimateFloat : AnimateValue<float>
    {
        private void Reset()
        {
            from = 0f;
            to = 1f;
        }

        protected override float GetValue(float tNormal)
        {
            return from + (to - from) * tNormal;
        }
    }


}
