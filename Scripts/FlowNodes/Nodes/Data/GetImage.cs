using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/GetImage", 409)]
    [NodeWidth(190)]
    public class GetImage : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public Transform _transform;
        [Output]
        public Image image;

        private NodePort transformPort;

        protected override void Init()
        {
            base.Init();

            transformPort = GetInputPort(nameof(_transform));
        }

        private void Reset()
        {
            Name = "Get Image";
        }

        public override object GetValue(NodePort port)
        {
            Transform t = transformPort.GetInputValue(_transform);
            if (t == null)
            {
                Debug.LogErrorFormat("Transform is null {0}.{1}", gameObject.name, Name);
                return null;
            }

            Image image = t.GetComponent<Image>();

            return image;
            
        }
    }
}
