using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetTextMeshProUGUIColor", 415)]
    [NodeWidth(220)]
    public class GetTextMeshProUGUIColor : GetObjectParameter<TextMeshProUGUI, Color>
    {
        protected override Color GetValue(TextMeshProUGUI obj)
        {
            return obj.color;
        }
    }
}
