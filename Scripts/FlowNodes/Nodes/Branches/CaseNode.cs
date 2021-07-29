using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Unity/Case")]
    [NodeWidth(280)]
    public class CaseNode : FlowNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public UnityEngine.Object    Switch = null;

        [Output(dynamicPortList: true)]
        public UnityEngine.Object[]  Case;

        public override void OnEnable()
        {
            base.OnEnable();
            // Для удобства изменим подпись к стандартным flow портам

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

        public override void ExecuteNode()
        {
        }

        public override void TriggerFlow()
        {
            if (Case.Length <= 0)
            {
                FlowUtils.TriggerFlow(Outputs, nameof(FlowOutput));
                return;
            }

            Switch = GetInputValue(nameof(Switch), Switch);

            bool caseDefault = true;
            for (int i = 0; i < Case.Length; i++)
            {
                if (Switch == Case[i])
                {
                    FlowUtils.TriggerFlow(Outputs, $"{nameof(Case)} {i}");
                    caseDefault = false;
                    // return; may be multiple choices!
                }
            }

            if (caseDefault)
            {
                FlowUtils.TriggerFlow(Outputs, nameof(FlowOutput));
            }
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
