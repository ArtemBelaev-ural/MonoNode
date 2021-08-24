using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/" + nameof(GetTransform), 405)]
    [NodeWidth(240)]
    public class GetTransform : MonoNode
    {
        [Input(backingValue: ShowBackingValue.Unconnected)] public GameObject input;
        [Output] public Transform _transform;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(_transform))
            {
                input = GetInputValue(nameof(input), input);
                if (input == null)
                {
                    return null;
                }

                return input.transform;
            }

            return null;
        }
    }
}
