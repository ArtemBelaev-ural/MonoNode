using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/GetXYZ", 44)]
    public class Vector3GetXYZ : MonoNode
    {
        [Input] public Vector3  a;

        [Output] public float   x;
        [Output] public float   y;
        [Output] public float   z;

        NodePort inputPort;

        protected override void Init()
        {
            inputPort = GetInputPort(nameof(a));
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(x))
            {
                return inputPort.GetInputValue(a).x;
            }
            else if (port.fieldName == nameof(y))
            {
                return inputPort.GetInputValue(a).y;
            }
            else if (port.fieldName == nameof(z))
            {
                return inputPort.GetInputValue(a).z;
            }
            else
                return null;
        }
    }
}
