using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetGraphicColor", 417)]
    [NodeWidth(190)]
    public class GetGraphicColor : GetObjectParameter<Graphic, Color>
    {
        protected override Color GetValue(Graphic obj)
        {
            return obj.color;
        }
    }
}
