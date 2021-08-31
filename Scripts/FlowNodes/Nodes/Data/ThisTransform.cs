using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/ThisTransform", 440)]
    [NodeWidth(140)]
    public class ThisTransform : MonoNode
    {
        [Output] public Transform output;

        private void Reset()
        {
            Name = "This Transform";
        }

        public override object GetValue(NodePort port)
        {
            return gameObject.transform;
        }
    }
}
