using System.Threading.Tasks;
using UnityEngine;

namespace XMonoNode
{
    [NodeWidth(160)]
    public abstract class WaitBase : FlowNode
    {
        [Input] public bool condition;

        protected bool triggered = false;
        private NodePort conditionPort = null;
        protected bool Condition
        {
            get
            {
                return conditionPort.GetInputValue(condition);
            }
        }

        protected override void Init()
        {
            base.Init();
            conditionPort = GetInputPort(nameof(condition));
            flowInputPort.label = "Enter";
            flowOutputPort.label = "Exit";
        }

        public override void TriggerFlow()
        {
            //base.TriggerFlow();
        }


        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }

        public override void Stop()
        {
            base.Stop();
            triggered = false;
        }

    }
}
