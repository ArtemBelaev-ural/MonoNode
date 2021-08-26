using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetImageComponent", 413)]
    [NodeWidth(190)]
    public class GetImageComponent : GetComponentBase<Image>
    {
        protected override void Init()
        {
            base.Init();

            objPort.label = "Transform";
            componentPort.label = "Image";
        }

        private void Reset()
        {
            Name = "Get Image Component";
        }
    }
}
