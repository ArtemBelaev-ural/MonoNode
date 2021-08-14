using System.Threading.Tasks;
using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Time/WaitWhile", 534)]
    public class WaitWhile : WaitBase
    {
        public override void Flow(NodePort flowPort)
        {
            triggered = true;
            Update();
        }

        private void Update()
        {
            if (triggered && !Condition)
            {
                FlowUtils.TriggerFlow(flowOutputPort);
                triggered = false;
            }
        }

    }
}
