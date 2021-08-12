using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Equals", 14)]
    public class Vector3Equals : MonoNode
    {
        [Input] public Vector3  a;
        [Input] public Vector3  b;

        [Output] public bool equals;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(equals))
            {
                return Vector3.Equals(GetInputValue(nameof(a), a), GetInputValue(nameof(b), b));
            }

            return null;
        }
    }
}
