using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Events/" + nameof(OnEnabled), 13)]
    public class OnEnabled : EventNode
    {
        public override void OnEnable()
        {
            base.OnEnable();
            TriggerFlow();
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
