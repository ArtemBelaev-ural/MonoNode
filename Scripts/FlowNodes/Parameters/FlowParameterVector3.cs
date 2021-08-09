using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает Vector3, переданный в метод FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Vector3", 0)]
    [CreateNodeMenu("Parameter/Vector3", 0)]
    public class FlowParameterVector3 : FlowParameter<Vector3>
    {
    }
}
