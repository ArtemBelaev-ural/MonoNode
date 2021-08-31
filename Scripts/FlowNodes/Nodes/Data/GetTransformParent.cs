using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/GetParent", 442)]
    public class GetTransformParent : GetObjectParameter<Transform, Transform>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Parent";
        }
        protected override Transform GetValue(Transform obj)
        {
            return obj.parent;
        }
    }
}
