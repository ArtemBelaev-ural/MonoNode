using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// Возвращает string, переданный в метод XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/string", 5)]
    [CreateNodeMenu("Parameter/string", 5)]
    public class ExecuteParameterString : ExecuteParameter<string>
    {
    }
}
