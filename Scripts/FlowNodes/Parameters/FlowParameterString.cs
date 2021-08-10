using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает string, переданный в метод XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/string", 7)]
    [CreateNodeMenu("Parameter/string", 7)]
    public class FlowParameterString : FlowParameter<string>
    {
    }
}
