using XMonoNode;

namespace XMonoNode
{
    public abstract class EventNode : MonoNode
    {
        [Output] public Flow FlowOutput;

        public void TriggerFlow()
        {
            FlowUtils.TriggerFlow(Outputs, nameof(EventNode.FlowOutput));
        }
    }
}
