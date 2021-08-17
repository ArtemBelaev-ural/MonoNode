using XMonoNode;
using UnityEngine;

namespace XMonoNode
{
    public abstract class EventNode : MonoNode
    {
        [Output, NodeInspectorButton(NodeInspectorButtonShow.Always)] public Flow FlowOutput;

        private NodePort flowOutputPort;

        public NodePort FlowOutputPort
        {
            get => flowOutputPort;
            set => flowOutputPort = value;
        }

        protected override void Init()
        {
            base.Init();
            FlowOutputPort = GetOutputPort(nameof(FlowOutput));
        }

        public void TriggerFlow()
        {
            FlowUtils.TriggerFlow(FlowOutputPort);
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
