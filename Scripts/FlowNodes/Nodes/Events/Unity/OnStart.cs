using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Events/OnStart")]
    public class OnStart : EventNode
    {
        private void Start()
        {
            TriggerFlow();
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
