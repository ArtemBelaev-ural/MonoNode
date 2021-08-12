using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Expose", 2)]
    public class Vector3Expose : MonoNode
    {
        [Input] public Vector3      vector3;

        [Output] public float       x;
        [Output] public float       y;
        [Output] public float       z;
        [Output] public Vector3     normalized;
        [Output] public float       magnitude;
        [Output] public float       sqrMagnitude;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            vector3 = GetInputValue(nameof(vector3), vector3);

            if (port.fieldName == nameof(x))
            {
                return vector3.x;
            }
            else if (port.fieldName == nameof(y))
            {
                return vector3.y;
            }
            else if (port.fieldName == nameof(z))
            {
                return vector3.z;
            }
            else if (port.fieldName == nameof(normalized))
            {
                return vector3.normalized;
            }
            else if (port.fieldName == nameof(magnitude))
            {
                return vector3.magnitude;
            }
            if (port.fieldName == nameof(sqrMagnitude))
            {
                return vector3.sqrMagnitude;
            }

            return null;
        }
    }
}
