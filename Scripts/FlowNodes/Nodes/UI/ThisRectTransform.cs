using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/ThisRectTransform", 404)]
    [NodeWidth(140)]
    public class ThisRectTransform : MonoNode
    {
        [Output] public RectTransform output;

        private UnityEngine.UI.Graphic graphic = null;

        protected override void Init()
        {
            base.Init();

            graphic = GetComponent<UnityEngine.UI.Graphic>();
        }

        private void Reset()
        {
            Name = "This RectTransform";
        }

        public override object GetValue(NodePort port)
        {
            if (graphic != null && port.fieldName == nameof(output))
            {
                return graphic.rectTransform;
            }
            return null;
        }
    }
}
