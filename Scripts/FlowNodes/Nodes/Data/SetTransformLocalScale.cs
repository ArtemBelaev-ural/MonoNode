using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/SetLocalScale", 460)] 
    public class SetTransformLocalScale : SetObjectParameter<Transform, Vector3>
    {
        protected override void Init()
        {
            base.Init();
            ParameterPort.label = "Local Scale";
        }

        protected override void SetValue(Transform obj, Vector3 value)
        {
            obj.localScale = value;
        }
    }
}
