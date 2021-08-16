using System.Threading.Tasks;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Time/WaitForNextFrame", 536)]
    public class WaitForNextFrameNode : FlowNode
    {
        private long flowUpdateNumber = -1;

        private void Reset()
        {
            Name = "Wait For Next Frame";
        }
        protected override void Init()
        {
            base.Init();

            FlowInputPort.label = "Enter";
            FlowOutputPort.label = "Exit";
        }

        public override void TriggerFlow()
        {
            //base.TriggerFlow(); 
        }

        public override void Flow(NodePort flowPort)
        {
            if (flowPort == FlowInputPort)
            {
                flowUpdateNumber = Time.frameCount + 1;
            }
        }

        private void Update()
        {
            if (flowUpdateNumber == Time.frameCount)
            {
                FlowUtils.TriggerFlow(FlowOutputPort);
                flowUpdateNumber = -1;
            }
        }

        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }

        public override void Stop()
        {
            base.Stop();
            flowUpdateNumber = -1;
        }

    }
}
