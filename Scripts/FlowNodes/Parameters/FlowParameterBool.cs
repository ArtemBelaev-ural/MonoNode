using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает bool, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/bool", 6)]
    [CreateNodeMenu("Parameter/bool", 6)]
    public class FlowParameterBool : FlowParameter<bool>
    {
    }
}
