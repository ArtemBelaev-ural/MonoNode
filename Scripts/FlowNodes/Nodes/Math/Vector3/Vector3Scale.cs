using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Scale", 5)]
    public class Vector3Scale : MonoNode
    {
        [Input] public Vector3  vector3;
        [Input] public float    scale;

        [Output] public Vector3 scaled;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(scaled))
            {

                return GetInputValue(nameof(vector3), vector3) * GetInputValue(nameof(scale), scale);
            }

            return null;
        }
    }
}
