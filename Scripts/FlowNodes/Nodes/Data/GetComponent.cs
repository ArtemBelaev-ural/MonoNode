using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/GetComponent", 408)]
    [NodeWidth(220)]
    public class GetComponent : GetComponentBase<Component>
    {
        [Input(connectionType: ConnectionType.Override)]
        public string type;

        private void Reset()
        {
            Name = "Get Component";
        }

        protected override void Init()
        {
            base.Init();

            objPort.label = "Transform";
        }

        public override object GetValue(NodePort port)
        {
            Transform t = objPort.GetInputValue(obj);
            if (t == null)
            {
                return null;
            }

            type = GetInputValue(nameof(type), type);

            return t.GetComponent(type);
        }
    }
}
