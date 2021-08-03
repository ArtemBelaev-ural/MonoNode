using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Events/OnStart", 11)]
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
