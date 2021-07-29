using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает GameObject, переданный в метод FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter//GameObject", 2)]
    [CreateNodeMenu("Parameter/GameObject", 2)]
    public class ExecuteParameterGameObject : ExecuteParameter<GameObject>
    {
    }
}
