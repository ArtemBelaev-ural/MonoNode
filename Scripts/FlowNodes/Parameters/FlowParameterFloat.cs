using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� float, ���������� � ����� FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/float", 4)]
    [CreateNodeMenu("Parameter/float", 4)]
    public class FlowParameterFloat : FlowParameter<float>
    {
        private void Reset()
        {
            Name = "PlayParam: float"; // � ��������� ���������� single
        }
    }
}
