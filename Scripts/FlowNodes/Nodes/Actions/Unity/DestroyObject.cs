﻿using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/"+nameof(DestroyObject))]
    public class DestroyObject : FlowNode {
        [Input]
        public GameObject Target;

        public override void ExecuteNode() {
            var toDestroy = GetInputValue<GameObject>(nameof(Target), Target);
            Destroy(toDestroy);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
