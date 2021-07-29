using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// ���������� Vector3, ���������� � ����� XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Vector3", 0)]
    [CreateNodeMenu("Parameter/Vector3", 0)]
    public class ExecuteParameterVector3 : ExecuteParameter<Vector3>
    {
    }
}
