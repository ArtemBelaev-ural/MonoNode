using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetGraphicComponent", 410)]
    [NodeWidth(190)]
    public class GetGraphicComponent : GetComponentBase<Graphic>
    {
        protected override void Init()
        {
            base.Init();

            objPort.label = "Transform";
            componentPort.label = "Graphic";
        }

        private void Reset()
        {
            Name = "Get Graphic Component";
        }
    }
}
