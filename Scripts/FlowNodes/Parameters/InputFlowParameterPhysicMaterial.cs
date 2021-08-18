using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� TransformPhysicMaterial, ���������� � ����� FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/Input/PhysicMaterial", 3)]
    [CreateNodeMenu("Parameter/Input/PhysicMaterial", 3)]
    public class InputFlowParameterPhysicMaterial : InputFlowParameter<PhysicMaterial>
    {
    }
}
