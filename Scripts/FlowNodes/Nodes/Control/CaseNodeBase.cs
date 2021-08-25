using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [NodeWidth(280)]
    public abstract class CaseNodeBase<T> : FlowNodeInOut
    {
        [Input(connectionType: ConnectionType.Override)]
        public T    Switch = default(T);

        [Output(dynamicPortList: true, backingValue: ShowBackingValue.Always), NodeInspectorButton, FlowPort]
        public T[]  Case = new T[0];

        protected override void Init()
        {
            base.Init();
            NodePort portIn = GetInputPort(nameof(FlowInput));
            if (portIn != null)
            {
                portIn.label = "Switch";
            }
            NodePort portOut = GetOutputPort(nameof(FlowOutput));
            if (portOut != null)
            {
                portOut.label = "Default";
            }
        }

        public override void OnNodeEnable()
        {
            base.OnNodeEnable();
            // Для удобства изменим подпись к стандартным flow портам
        }

        public override void Flow(NodePort flowPort)
        {
            if (Case.Length <= 0)
            {
                FlowUtils.FlowOutput(FlowOutputPort);
                return;
            }

            Switch = GetInputValue(nameof(Switch), Switch);
            bool caseDefault = true;
            if (Switch != null)
            {
                for (int i = 0; i < Case.Length; i++)
                {
                    if (Switch.Equals(Case[i]))
                    {
                        FlowUtils.FlowOutput(GetOutputPort($"{nameof(Case)} {i}"));
                        caseDefault = false;
                        // return; may be multiple choices!
                    }
                }
            }

            if (caseDefault)
            {
                FlowUtils.FlowOutput(FlowOutputPort);
            }
        }

        public override void TriggerFlow()
        {
            
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            for (int i = 0; i < Case.Length; ++i)
            {
                if (port.fieldName == $"{nameof(Case)} {i}")
                {
                    return Case[i];
                }
            }
            return null;
        }
    }
}
