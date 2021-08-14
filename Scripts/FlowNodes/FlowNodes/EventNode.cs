using XMonoNode;
using UnityEngine;

namespace XMonoNode
{
    public abstract class EventNode : MonoNode
    {
        [Output] public Flow FlowOutput;

        protected NodePort flowOutputPort;

        protected override void Init()
        {
            base.Init();
            flowOutputPort = GetOutputPort(nameof(FlowOutput));
        }

        public void TriggerFlow()
        {
            FlowUtils.TriggerFlow(flowOutputPort);
        }
    }
}
