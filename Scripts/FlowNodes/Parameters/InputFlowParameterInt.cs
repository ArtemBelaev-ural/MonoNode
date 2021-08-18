using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� int, ���������� � ����� FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Input/int", 5)]
    [CreateNodeMenu("Parameter/Input/int", 5)]
    public class InputFlowParameterInt : InputFlowParameter<int>
    {
    }
}
