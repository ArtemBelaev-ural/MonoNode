using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Join", 1)]
    [NodeWidth(160)]
    public class Vector3Join : MonoNode
    {
        [Input] public float x;
        [Input] public float y;
        [Input] public float z;

        [Output] public Vector3 vector3;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(vector3))
            {
                var x = GetInputValue(nameof(Vector3Join.x), this.x);
                var y = GetInputValue(nameof(Vector3Join.y), this.y);
                var z = GetInputValue(nameof(Vector3Join.z), this.z);

                return new Vector3(x, y, z);
            }

            return null;
        }
    }
}
