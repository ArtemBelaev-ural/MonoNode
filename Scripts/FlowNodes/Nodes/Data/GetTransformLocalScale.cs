using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/GetLocalScale", 459)]
    public class GetTransformLocalScale : GetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Local Scale";
        }
        protected override Vector3 GetValue(Transform obj)
        {
            return obj.localScale;
        }
    }
}
