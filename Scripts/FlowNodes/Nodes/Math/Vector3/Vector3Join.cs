using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Join", 1)]
    [NodeWidth(160)]
    public class Vector3Join : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public float x;

        [Input(connectionType: ConnectionType.Override)]
        public float y;

        [Input(connectionType: ConnectionType.Override)]
        public float z;

        [Output] public Vector3 vector3;

        private NodePort xPort;
        private NodePort yPort;
        private NodePort zPort;

        protected override void Init()
        {
            base.Init();
            xPort = GetInputPort(nameof(x));
            yPort = GetInputPort(nameof(y));
            zPort = GetInputPort(nameof(z));
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return new Vector3(xPort.GetInputValue(x), yPort.GetInputValue(y), zPort.GetInputValue(z));
        }
    }
}
