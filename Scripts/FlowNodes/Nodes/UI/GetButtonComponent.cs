using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetButtonComponent", 412)]
    [NodeWidth(190)]
    public class GetButtonComponent : GetComponentBase<Button>
    {
        protected override void Init()
        {
            base.Init();

            objPort.label = "Transform";
            componentPort.label = "Button";
        }

        private void Reset()
        {
            Name = "Get Button Component";
        }
    }
}
