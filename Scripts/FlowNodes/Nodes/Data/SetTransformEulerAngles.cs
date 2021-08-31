using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/SetEulerAngles", 456)] 
    public class SetTransformEulerAngles : SetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Euler Angles";
        }

        protected override void SetValue(Transform obj, Vector3 value)
        {
            obj.eulerAngles = value;
        }
    }
}
