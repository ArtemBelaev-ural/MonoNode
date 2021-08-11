using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Angle", 11)]
    public class Vector3Angle : MonoNode
    {
        [Input] public Vector3  from;
        [Input] public Vector3  to;

        [Output] public Vector3 angle;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(angle))
            {
                return Vector3.Angle(GetInputValue(nameof(from), from), GetInputValue(nameof(to), to));
            }

            return null;
        }
    }
}
