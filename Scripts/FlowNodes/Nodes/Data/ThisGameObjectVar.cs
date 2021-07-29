using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("GameObject/ThisGameObject")]
    [NodeWidth(140)]
    public class ThisGameObject : MonoNode
    {
        [Output] public GameObject output;

        private void Reset()
        {
            Name = "ThisGameObject";
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(output))
            {
                return gameObject;
            }
            return null; // Replace this
        }
    }
}
