using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetGraphicColor", 415)]
    [NodeWidth(190)]
    public class GetGraphicColor : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public Graphic graphic;

        [Output]
        public Color color;

        public override object GetValue(NodePort port)
        {
            var obj = GetInputValue(nameof(graphic), graphic);
            return obj ? obj.color : Color.black;
        }
    }
}
