using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает TransformPhysicMaterial, переданный в метод FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/PhysicMaterial", 3)]
    [CreateNodeMenu("Parameter/PhysicMaterial", 3)]
    public class ExecuteParameterPhysicMaterial : ExecuteParameter<PhysicMaterial>
    {
    }
}
