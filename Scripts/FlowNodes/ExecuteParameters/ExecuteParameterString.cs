using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� string, ���������� � ����� XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/string", 6)]
    [CreateNodeMenu("Parameter/string", 6)]
    public class ExecuteParameterString : ExecuteParameter<string>
    {
    }
}
