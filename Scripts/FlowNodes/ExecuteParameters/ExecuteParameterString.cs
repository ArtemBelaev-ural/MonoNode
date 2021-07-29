using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� string, ���������� � ����� XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/string", 5)]
    [CreateNodeMenu("Parameter/string", 5)]
    public class ExecuteParameterString : ExecuteParameter<string>
    {
    }
}
