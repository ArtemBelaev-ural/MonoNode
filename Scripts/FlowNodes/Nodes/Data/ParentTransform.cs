using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/ParentTransform", 403)]
    [NodeWidth(140)]
    public class ParentTransform : MonoNode
    {
        [Output] public Transform parent;


        private void Reset()
        {
            Name = "Parent Transform";
        }

        public override object GetValue(NodePort port)
        {
            return gameObject.transform.parent;
        }
    }
}
