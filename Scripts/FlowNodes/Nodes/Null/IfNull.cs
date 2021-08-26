using XMonoNode;
using UnityEngine;

namespace XMonoNode
{
    [NodeWidth(130)]
    [CreateNodeMenu("Null/IfNull", 1011)]
    public class IfNull : FlowNodeInOut
    {
        [Inline]
        [Input(backingValue: ShowBackingValue.Never, connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.None)]
        public Object value = null;

        [Output, NodeInspectorButton] public Flow notNull;

        NodePort _objectPort;
        NodePort notNullPort;

        protected override void Init()
        {
            base.Init();
            FlowOutputPort.label = "Null";

            _objectPort = GetInputPort(nameof(value));
            notNullPort = GetOutputPort(nameof(notNull));
        }

        public override void TriggerFlow()
        {
            //base.TriggerFlow();
        }

        public override void Flow(NodePort flowPort)
        {
            NodePort output = _objectPort.GetInputValue(value) == null ? FlowOutputPort : notNullPort;
            FlowUtils.FlowOutput(output);
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
