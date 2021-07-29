using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� float, ���������� � ����� XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/float", 3)]
    [CreateNodeMenu("Parameter/float", 3)]
    public class ExecuteParameterFloat : ExecuteParameter<float>
    {
        private void Reset()
        {
            Name = "PlayParam: float"; // � ��������� ���������� single
        }
    }
}
