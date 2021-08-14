using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Sum", 3)]
    public class Vector3Sum : MonoNode
    {
        [Input] public Vector3 a;
        [Input] public Vector3 b;

        [Output] public Vector3 sum;

        NodePort inputPortA;
        NodePort inputPortB;

        protected override void Init()
        {
            base.Init();
            NodePort port = GetOutputPort(nameof(sum));
            if (port != null)
            {
                port.label = "A + B";
            }
            inputPortA = GetInputPort(nameof(a));
            inputPortB = GetInputPort(nameof(b));
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(sum))
            {

                return inputPortA.GetInputValue(a) + inputPortB.GetInputValue(b);
            }

            return null; // Replace this
        }
    }
}
