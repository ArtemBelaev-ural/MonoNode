using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/SetPosition", 452)]
    public class SetTransformPosition : SetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Position";
        }

        protected override void SetValue(Transform obj, Vector3 value)
        {
            obj.position = value;
        }
    }
}
