using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Cross", 13)]
    public class Vector3Cross : MonoNode
    {
        [Input] public Vector3  a;
        [Input] public Vector3  b;

        [Output] public Vector3 cross;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(cross))
            {
                return Vector3.Cross(GetInputValue(nameof(a), a), GetInputValue(nameof(b), b));
            }

            return null;
        }
    }
}
