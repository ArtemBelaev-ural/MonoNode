using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� int, ���������� � ����� FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/int", 5)]
    [CreateNodeMenu("Parameter/int", 5)]
    public class FlowParameterInt : FlowParameter<int>
    {
    }
}
