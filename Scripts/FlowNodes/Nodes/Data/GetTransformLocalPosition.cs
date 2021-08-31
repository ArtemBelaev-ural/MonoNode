using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/GetLocalPosition", 453)]
    public class GetTransformLocalPosition : MonoNode
    {
        [Input(connectionType:ConnectionType.Override)]
        public Transform _transform;
        [Output]
        public Vector3 localPosition;

        private NodePort transformPort;

        protected override void Init()
        {
            base.Init();

            transformPort = GetInputPort(nameof(_transform));
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            Transform target = transformPort.GetInputValue(_transform);
            if (target == null)
            {
                return Vector3.zero;
            }

            return target.localPosition;
        }
    }
}
