using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/SignedAngle", 12)]
    public class Vector3SignedAngle : MonoNode
    {
        [Input] public Vector3  from;
        [Input] public Vector3  to;
        [Input] public Vector3  axis;

        [Output] public Vector3 angle;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(angle))
            {
                return Vector3.SignedAngle(GetInputValue(nameof(from), from), GetInputValue(nameof(to), to), GetInputValue(nameof(axis), axis));
            }

            return null;
        }
    }
}
