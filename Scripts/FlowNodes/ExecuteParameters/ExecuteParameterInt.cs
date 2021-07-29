using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� int, ���������� � ����� FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/int", 5)]
    [CreateNodeMenu("Parameter/int", 5)]
    public class XSoundNodeIntParameter : ExecuteParameter<int>
    {
    }
}
