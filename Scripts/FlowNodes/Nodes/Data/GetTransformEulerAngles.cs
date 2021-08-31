using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/GetEulerAngles", 455)]
    public class GetTransformEulerAngles : GetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Euler Angles";
        }

        protected override Vector3 GetValue(Transform obj)
        {
            return obj.eulerAngles;
        }
    }
}
