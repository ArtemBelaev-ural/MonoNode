using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает GameObject, переданный в метод FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter//GameObject", 2)]
    [CreateNodeMenu("Parameter/GameObject", 2)]
    public class FlowParameterGameObject : FlowParameter<GameObject>
    {
    }
}
