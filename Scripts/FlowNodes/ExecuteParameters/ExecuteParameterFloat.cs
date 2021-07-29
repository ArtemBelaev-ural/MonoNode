using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает float, переданный в метод FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/float", 4)]
    [CreateNodeMenu("Parameter/float", 4)]
    public class ExecuteParameterFloat : ExecuteParameter<float>
    {
        private void Reset()
        {
            Name = "PlayParam: float"; // в оригинале получается single
        }
    }
}
