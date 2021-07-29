using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� TransformPhysicMaterial, ���������� � ����� FlowNodeGraph.Execute()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/PhysicMaterial", 3)]
    [CreateNodeMenu("Parameter/PhysicMaterial", 3)]
    public class ExecuteParameterPhysicMaterial : ExecuteParameter<PhysicMaterial>
    {
    }
}
