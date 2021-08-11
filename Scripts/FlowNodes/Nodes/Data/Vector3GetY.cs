using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/GetY", 42)]
    public class Vector3GetY : MonoNode
    {
        [Input] public Vector3  a;

        [Output] public float   y;

        NodePort inputPort;

        protected override void Init()
        {
            inputPort = GetInputPort(nameof(a));
        }

        public override object GetValue(NodePort port)
        {
            return inputPort.GetInputValue(a).y;
        }
    }
}
