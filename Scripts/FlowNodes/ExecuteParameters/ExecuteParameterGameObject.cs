using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� GameObject, ���������� � ����� FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter//GameObject", 2)]
    [CreateNodeMenu("Parameter/GameObject", 2)]
    public class ExecuteParameterGameObject : ExecuteParameter<GameObject>
    {
    }
}
