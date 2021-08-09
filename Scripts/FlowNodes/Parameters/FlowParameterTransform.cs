using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает Transform, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Transform", 1)]
    [CreateNodeMenu("Parameter/Transform", 1)]
    public class FlowParameterTransform : FlowParameter<Transform>
    {
    }
}
