using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// Возвращает float, переданный в метод XSoundNodeGraph.Play()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/float", 3)]
    [CreateNodeMenu("Parameter/float", 3)]
    public class ExecuteParameterFloat : ExecuteParameter<float>
    {
        private void Reset()
        {
            Name = "PlayParam: float"; // в оригинале получается single
        }
    }
}
