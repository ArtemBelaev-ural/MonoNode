using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� Vector3, ���������� � ����� FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Vector3", 0)]
    [CreateNodeMenu("Parameter/Vector3", 0)]
    public class FlowParameterVector3 : FlowParameter<Vector3>
    {
    }
}
