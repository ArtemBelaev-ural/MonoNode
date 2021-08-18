using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� Vector3, ���������� � ����� FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Input/Vector3", 0)]
    [CreateNodeMenu("Parameter/Input/Vector3", 0)]
    public class InputFlowParameterVector3 : InputFlowParameter<Vector3>
    {
    }
}
