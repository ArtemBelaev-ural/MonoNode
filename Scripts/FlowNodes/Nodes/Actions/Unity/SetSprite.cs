using UnityEngine;
using XNode;

namespace FlowNodes
{
    [CreateNodeMenu("UI/" + nameof(SetSprite))]
    public class SetSprite : FlowNode
    {
        [Input] public SpriteRenderer Target;
        [Input] public Sprite MySprite;

        public override void ExecuteNode()
        {
            var target = GetInputValue(nameof(Target), Target);
            var sprite = GetInputValue(nameof(MySprite), MySprite);
            target.sprite = sprite;
        }

        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}