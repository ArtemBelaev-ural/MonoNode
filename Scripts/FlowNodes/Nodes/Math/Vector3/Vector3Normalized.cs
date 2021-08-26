using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Normalized", 8)]
    [NodeWidth(180)]
    public class Vector3Normalized : MonoNode
    {
        [Input(connectionType: ConnectionType.Override)]
        public Vector3  vector3;

        [Output] public Vector3 normalized;

        private NodePort inputPort;

        protected override void Init()
        {
            base.Init();

            inputPort = GetInputPort(nameof(vector3));
        }

        public override object GetValue(NodePort port)
        {
            return inputPort.GetInputValue(vector3).normalized;
        }
    }
}
