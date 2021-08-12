using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/" + nameof(GetTransform), 405)]
    [NodeWidth(190)]
    public class GetTransform : MonoNode
    {
        [Input] public GameObject input;
        [Output] public Transform _transform;

        public override object GetValue(NodePort port)
        {
            input = GetInputValue(nameof(input), input);
            if (input == null)
            {
                return null;
            }

            if (port.fieldName == nameof(_transform))
            {
                return input.transform.position;
            }

            return null;
        }
    }
}
