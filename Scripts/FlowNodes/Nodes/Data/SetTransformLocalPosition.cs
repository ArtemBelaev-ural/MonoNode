using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/SetLocalPosition", 454)]
    public class SetTransformLocalPosition : SetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Local Position";
        }

        protected override void SetValue(Transform obj, Vector3 value)
        {
            obj.localPosition = value;
        }
    }
}
