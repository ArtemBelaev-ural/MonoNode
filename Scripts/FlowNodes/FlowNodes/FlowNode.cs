using XMonoNode;

namespace XMonoNode
{
    public abstract class FlowNode : MonoNode
    {
        [Input] public Flow FlowInput;
        [Output] public Flow FlowOutput;

        protected NodePort flowInputPort;
        protected NodePort flowOutputPort;

        protected override void Init()
        {
            base.Init();

            flowInputPort = GetInputPort(nameof(FlowInput));
            flowOutputPort = GetOutputPort(nameof(FlowOutput));

        }

        public virtual void TriggerFlow()
        {
            FlowUtils.TriggerFlow(flowOutputPort);
        }

        /// <summary>
        /// Handle input stream
        /// </summary>
        public abstract void Flow(NodePort flowPort);

        /// <summary>
        /// Stop execution of this flow node
        /// </summary>
        public virtual void Stop()
        {

        }


    }
}
