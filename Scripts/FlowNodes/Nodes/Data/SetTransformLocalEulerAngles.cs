using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/SetLocalEulerAngles", 458)] 
    public class SetTransformLocalEulerAngles : SetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Local Euler Angles";
        }

        protected override void SetValue(Transform obj, Vector3 value)
        {
            obj.eulerAngles = value;
        }
    }
}
