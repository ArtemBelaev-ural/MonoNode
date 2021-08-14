using System.Threading.Tasks;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Time/WaitForSeconds", 532)]
    public class WaitForSeconds : FlowNode
    {
        [Input] public float WaitSeconds;

        private bool flow = false;

        protected override void Init()
        {
            base.Init();
            GetInputPort(nameof(FlowInput)).label = "Enter";
            GetOutputPort(nameof(FlowOutput)).label = "Exit";
        }

        public override void TriggerFlow()
        {
            //base.TriggerFlow();
        }

        public override async void Flow(NodePort flowPort)
        {
            var secondsToWait = GetInputValue(nameof(WaitSeconds), WaitSeconds);
            if (secondsToWait > 0)
            {
                flow = true;
                await DoWait((int)(secondsToWait * 1000));
            }
        }

        public async Task DoWait(int waitMilliseconds)
        {
            await Task.Delay(waitMilliseconds);
            if (flow)
            {
                base.TriggerFlow();
            }
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }

        public override void Stop()
        {
            base.Stop();
            flow = false;
        }
    }
}
