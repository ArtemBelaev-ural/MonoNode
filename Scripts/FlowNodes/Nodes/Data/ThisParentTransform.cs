using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Transform/ThisParentTransform", 441)]
    [NodeWidth(140)]
    public class ThisParentTransform : MonoNode
    {
        [Output] public Transform parent;


        private void Reset()
        {
            Name = "This Parent Transform";
        }

        public override object GetValue(NodePort port)
        {
            return gameObject.transform.parent;
        }
    }
}
