using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// Возвращает GameObject, переданный в метод XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter//GameObject", 2)]
    [CreateNodeMenu("Parameter/GameObject", 2)]
    public class ExecuteParameterGameObject : ExecuteParameter<GameObject>
    {
    }
}
