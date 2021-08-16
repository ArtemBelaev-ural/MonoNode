﻿using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [NodeWidth(280)]
    public abstract class CaseNodeBase<T> : FlowNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public T    Switch = default(T);

        [Output(dynamicPortList: true)]
        public T[]  Case;

        public override void OnNodeEnable()
        {
            base.OnNodeEnable();
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

        public override void Flow(NodePort flowPort)
        {
        }

        public override void TriggerFlow()
        {
            if (Case.Length <= 0)
            {
                FlowUtils.TriggerFlow(FlowOutputPort);
                return;
            }

            Switch = GetInputValue(nameof(Switch), Switch);

            bool caseDefault = true;
            for (int i = 0; i < Case.Length; i++)
            {
                if (Switch.Equals(Case[i]))
                {
                    FlowUtils.TriggerFlow(GetOutputPort($"{nameof(Case)} {i}"));
                    caseDefault = false;
                    // return; may be multiple choices!
                }
            }

            if (caseDefault)
            {
                FlowUtils.TriggerFlow(FlowOutputPort);
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
