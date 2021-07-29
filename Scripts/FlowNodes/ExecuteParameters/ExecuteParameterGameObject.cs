using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// ���������� GameObject, ���������� � ����� XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter//GameObject", 2)]
    [CreateNodeMenu("Parameter/GameObject", 2)]
    public class ExecuteParameterGameObject : ExecuteParameter<GameObject>
    {
    }
}
