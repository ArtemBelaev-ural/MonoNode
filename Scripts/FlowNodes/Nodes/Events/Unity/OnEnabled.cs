﻿using XNode;

namespace FlowNodes
{
    [CreateNodeMenu("Events/" + nameof(OnEnabled))]
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
