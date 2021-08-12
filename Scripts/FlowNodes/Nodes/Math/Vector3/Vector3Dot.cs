using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Dot", 7)]
    public class Vector3Dot : MonoNode
    {
        [Input] public Vector3  a;
        [Input] public Vector3  b;

        [Output] public Vector3 dot;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(dot))
            {
                a = GetInputValue(nameof(a), a);
                Vector3 result = a;
                result.Scale(GetInputValue(nameof(b), b));
                return Vector3.Dot(GetInputValue(nameof(a), a), GetInputValue(nameof(b), b));
            }

            return null;
        }
    }
}
