using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// ���������� int, ���������� � ����� XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/int", 4)]
    [CreateNodeMenu("Parameter/int", 4)]
    public class XSoundNodeIntParameter : ExecuteParameter<int>
    {
    }
}
