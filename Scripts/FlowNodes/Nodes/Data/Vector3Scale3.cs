using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Scale3", 6)]
    public class Vector3Scale3 : MonoNode
    {
        [Input] public Vector3  vector3;
        [Input] public Vector3  scale;

        [Output] public Vector3 scaled;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(scaled))
            {
                vector3 = GetInputValue(nameof(vector3), vector3);
                Vector3 result = vector3;
                result.Scale(GetInputValue(nameof(scale), scale));
                return result;
            }

            return null;
        }
    }
}
