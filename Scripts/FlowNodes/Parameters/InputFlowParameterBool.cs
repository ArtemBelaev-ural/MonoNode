using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает bool, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Input/bool", 6)]
    [CreateNodeMenu("Parameter/Input/bool", 6)]
    public class InputFlowParameterBool : InputFlowParameter<bool>
    {
    }
}
