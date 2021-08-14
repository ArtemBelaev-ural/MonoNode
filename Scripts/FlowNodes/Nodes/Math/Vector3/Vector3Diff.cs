using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector3/Diff", 4)]
    public class Vector3Diff : MonoNode
    {
        [Input] public Vector3 a;
        [Input] public Vector3 b;

        [Output] public Vector3 difference;

        protected override void Init()
        {
            base.Init();

            NodePort portIn = GetOutputPort(nameof(difference));
            if (portIn != null)
            {
                portIn.label = "A - B";
            }
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(difference))
            {

                return GetInputValue(nameof(a), a) - GetInputValue(nameof(b), b);
            }

            return null; // Replace this
        }
    }
}
