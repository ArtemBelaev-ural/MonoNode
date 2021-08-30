using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    public abstract class SetObjectParameter<ObjType, ParamType> : FlowNodeInOut where ObjType : Object
    {
        [Input(connectionType: ConnectionType.Override)]
        public ObjType _object;

        [Input(connectionType: ConnectionType.Override)]
        public ParamType parameter;

        public NodePort ObjectPort => objectPort;
        private NodePort objectPort;

        public NodePort ParameterPort => parameterPort;
        private NodePort parameterPort;

        protected override void Init()
        {
            base.Init();

            objectPort = GetInputPort(nameof(_object));
            parameterPort = GetInputPort(nameof(parameter));
#if UNITY_EDITOR
            objectPort.label = UnityEditor.ObjectNames.NicifyVariableName(typeof(ObjType).PrettyName());
            parameterPort.label = UnityEditor.ObjectNames.NicifyVariableName(typeof(ParamType).PrettyName());
#endif
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public override void TriggerFlow()
        {
            
        }

        public override void Flow(NodePort flowPort)
        {
            ObjType obj = ObjectPort.GetInputValue(_object);
            if (obj != null)
            {
                SetValue(obj, parameterPort.GetInputValue(parameter));
                
            }
            FlowOut();
        }

        protected abstract void SetValue(ObjType obj, ParamType value);
    }
}
