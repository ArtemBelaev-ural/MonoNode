using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает GameObject, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Input/GameObject", 2)]
    [CreateNodeMenu("Parameter/Input/GameObject", 2)]
    public class InputFlowParameterGameObject : InputFlowParameter<GameObject>
    {
    }
}
