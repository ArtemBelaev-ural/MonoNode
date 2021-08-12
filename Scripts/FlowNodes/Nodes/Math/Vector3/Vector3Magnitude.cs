using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Magnitude", 7)]
    public class Vector3Magnitude : MonoNode
    {
        [Input] public Vector3  vector3;

        [Output] public float   magnitude;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(magnitude))
            {
                return GetInputValue(nameof(vector3), vector3).magnitude;
            }

            return null;
        }
    }
}
