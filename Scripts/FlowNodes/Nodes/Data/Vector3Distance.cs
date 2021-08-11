using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Distance", 10)]
    public class Vector3Distance : MonoNode
    {
        [Input] public Vector3 a;
        [Input] public Vector3 b;

        [Output] public float distance;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(distance))
            {
                return Vector3.Distance(GetInputValue(nameof(a), a), GetInputValue(nameof(b), b));
            }

            return null; // Replace this
        }
    }
}
