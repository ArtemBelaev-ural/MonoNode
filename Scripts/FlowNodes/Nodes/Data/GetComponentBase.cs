using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    public abstract class GetComponentBase<ComponemtType> : MonoNode where ComponemtType : Component
    {
        [Input(connectionType: ConnectionType.Override)]
        public Transform obj;

        protected NodePort objPort;

        [Output]
        public ComponemtType component;

        protected NodePort componentPort;

        protected override void Init()
        {
            base.Init();

            objPort = GetInputPort(nameof(obj));
            componentPort = GetOutputPort(nameof(component));

            objPort.label = "Transform";
            componentPort.label = UnityEditor.ObjectNames.NicifyVariableName(typeof(ComponemtType).PrettyName());
        }

        public override object GetValue(NodePort port)
        {
            Transform t = objPort.GetInputValue(obj);
            if (t == null)
            {
                return null;
            }

            return t.GetComponent<ComponemtType>();
        }
    }
}
