using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/LookAt (Transform)", 464)]
    public class LookAtTransform : SetObjectParameter<Transform, Transform> 
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Target";
        }

        protected override void SetValue(Transform obj, Transform value)
        {
            obj.LookAt(value);
        }
    }
}
