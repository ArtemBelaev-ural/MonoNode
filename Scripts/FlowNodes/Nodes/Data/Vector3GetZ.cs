using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/GetZ", 43)]
    public class Vector3GetZ : MonoNode
    {
        [Input] public Vector3  a;

        [Output] public float   z;

        NodePort inputPort;

        protected override void Init()
        {
            inputPort = GetInputPort(nameof(a));
        }

        public override object GetValue(NodePort port)
        {
            return inputPort.GetInputValue(a).z;
        }
    }
}
