using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetRectTransform", 408)]
    [NodeWidth(190)]
    public class GetRectTransform : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public Transform _transform;
        [Output] public RectTransform rectTransform;

        private NodePort transformPort;

        protected override void Init()
        {
            base.Init();

            transformPort = GetInputPort(nameof(_transform));
        }

        private void Reset()
        {
            Name = "Get RectTransform";
        }

        public override object GetValue(NodePort port)
        {
            Transform t = transformPort.GetInputValue(_transform);
            if (t == null)
            {
                Debug.LogErrorFormat("Transform is null {0}.{1}", gameObject.name, Name);
                return null;
            }

            UnityEngine.UI.Graphic graphic = t.GetComponent<UnityEngine.UI.Graphic>();
            if (graphic == null)
            {
                Debug.LogErrorFormat("Graphic component is null {0}.{1}", gameObject.name, Name);
                return null;
            }

            return graphic.rectTransform;
            
        }
    }
}
