using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/" + nameof(SetImageFill), "Sprite")]
    public class SetImageFill : FlowNode
    {
        [Input] public Image Target;
        [Input] public float Fill;

        public override void Flow()
        {
            var target = GetInputValue(nameof(Target), Target);
            var fillAmount = GetInputValue(nameof(Fill), Fill);
            target.fillAmount = fillAmount;
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}
