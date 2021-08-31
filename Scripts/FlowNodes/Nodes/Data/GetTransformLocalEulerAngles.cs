using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/GetLocalEulerAngles", 457)]
    public class GetTransformLocalEulerAngles : GetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Local Euler Angles";
        }
        protected override Vector3 GetValue(Transform obj)
        {
            return obj.localEulerAngles;
        }
    }
}
