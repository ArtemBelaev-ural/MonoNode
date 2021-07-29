using UnityEngine;
using XNode;

namespace FlowNodes
{
    [CreateNodeMenu("Math/" + nameof(JoinVector3), 201)]
    public class JoinVector3 : MonoNode
    {
        [Input] public float X;
        [Input] public float Y;
        [Input] public float Z;

        [Output] public Vector3 Result;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                var x = GetInputValue<float>(nameof(X), X);
                var y = GetInputValue<float>(nameof(Y), Y);
                var z = GetInputValue<float>(nameof(Z), Z);

                return new Vector3(x, y, z);
            }

            return null; // Replace this
        }
    }
}
