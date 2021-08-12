using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Utils/GraphName", 523)]
    [NodeWidth(150)]
    public class GraphName : MonoNode 
    {
        [Output] public string graphObjectName;

        public override object GetValue(NodePort port) 
        {
            return graph.gameObject.name;
        }
    }
}
