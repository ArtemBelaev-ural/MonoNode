using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector2/Zero", 21)]
    [NodeWidth(130)]
    public class Vector2Zero : MonoNode
    {
        [Output] public Vector2 zero;

        public override object GetValue(NodePort port)
        {
            return Vector2.zero;
        }
    }
}
