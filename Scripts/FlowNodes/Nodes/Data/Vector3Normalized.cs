using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Normalized", 8)]
    public class Vector3Normalized : MonoNode
    {
        [Input] public Vector3  vector3;

        [Output] public Vector3 normalized;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(normalized))
            {
                return GetInputValue(nameof(vector3), vector3).normalized;
            }

            return null;
        }
    }
}
