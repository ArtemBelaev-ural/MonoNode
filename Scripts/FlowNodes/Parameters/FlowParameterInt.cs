using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает int, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/int", 5)]
    [CreateNodeMenu("Parameter/int", 5)]
    public class FlowParameterInt : FlowParameter<int>
    {
    }
}
