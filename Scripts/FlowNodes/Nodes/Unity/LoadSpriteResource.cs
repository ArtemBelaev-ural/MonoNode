using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/" + nameof(LoadSpriteResource), "Load", "Image", "Sprite")]
    public class LoadSpriteResource : FlowNodeInOut
    {
        [Input] public string SpriteName;
        [Output] public Sprite Result;

        public override void Flow(NodePort flowPort)
        {
            var spriteName = GetInputValue(nameof(SpriteName), SpriteName);
            Debug.Log($"Loading from resources {spriteName.ToLower()}");
            Result = Resources.Load<Sprite>(spriteName.ToLower());
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                return Result;
            }
            return null; // Replace this
        }
    }
}
