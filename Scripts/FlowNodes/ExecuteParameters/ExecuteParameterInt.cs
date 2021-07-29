using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает int, переданный в метод FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/int", 5)]
    [CreateNodeMenu("Parameter/int", 5)]
    public class XSoundNodeIntParameter : ExecuteParameter<int>
    {
    }
}
