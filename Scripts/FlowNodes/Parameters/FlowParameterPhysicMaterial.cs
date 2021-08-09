using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� TransformPhysicMaterial, ���������� � ����� FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/PhysicMaterial", 3)]
    [CreateNodeMenu("Parameter/PhysicMaterial", 3)]
    public class FlowParameterPhysicMaterial : FlowParameter<PhysicMaterial>
    {
    }
}
