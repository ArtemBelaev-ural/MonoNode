using XMonoNode;

namespace XMonoNode
{
    public abstract class FlowNode : MonoNode
    {
        [Input] public Flow FlowInput;
        [Output] public Flow FlowOutput;

        public virtual void TriggerFlow()
        {
            FlowUtils.TriggerFlow(Outputs, nameof(FlowOutput));
        }

        /// <summary>
        /// Handle input stream
        /// </summary>
        public abstract void Flow();

        /// <summary>
        /// Stop execution of this flow node
        /// </summary>
        public virtual void Stop()
        {

        }
    }
}
