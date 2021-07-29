using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// Возвращает Vector3, переданный в метод XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Vector3", 0)]
    [CreateNodeMenu("Parameter/Vector3", 0)]
    public class ExecuteParameterVector3 : ExecuteParameter<Vector3>
    {
    }
}
