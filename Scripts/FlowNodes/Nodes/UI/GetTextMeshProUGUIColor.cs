using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetTextMeshProUGUIColor", 415)]
    [NodeWidth(190)]
    public class GetTextMeshProUGUIColor : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public TextMeshProUGUI TMProUGUI;

        [Output]
        public Color color;

        public override object GetValue(NodePort port)
        {
            var obj = GetInputValue(nameof(TMProUGUI), TMProUGUI);
            return obj ? obj.color : Color.black;
        }
    }
}
