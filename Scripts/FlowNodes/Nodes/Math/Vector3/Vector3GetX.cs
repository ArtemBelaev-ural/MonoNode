using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/GetX", -9)]
    public class Vector3GetX : MonoNode
    {
        [Input] public Vector3  a;

        [Output] public float   x;

        NodePort inputPort;

        protected override void Init()
        {
            inputPort = GetInputPort(nameof(a));
        }

        public override object GetValue(NodePort port)
        {
            return inputPort.GetInputValue(a).x;
        }
    }
}
