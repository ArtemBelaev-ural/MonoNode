using System.Threading.Tasks;
using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Time/WaitUntil", 533)]
    public class WaitUntil : WaitBase
    {
        public override void Flow(NodePort flowPort)
        {
            triggered = true;
            Update();
        }

        private void Update()
        {
            if (triggered && Condition)
            {
                FlowUtils.TriggerFlow(flowOutputPort);
                triggered = false;
            }
        }

    }
}
