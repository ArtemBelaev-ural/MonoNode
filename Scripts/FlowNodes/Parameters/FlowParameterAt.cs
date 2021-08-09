using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ���������� float, ���������� � ����� FlowNodeGraph.Flow()
    /// </summary>
    [AddComponentMenu("FlowNode/Parameter/At", 14)]
    [CreateNodeMenu("Parameter/At", 14)]
    [NodeTint(50, 70, 105)]
    [NodeWidth(160)]
    public class FlowParameterAt : FlowParameter
    {
        [Input]
        public int at = 0;

        [Output] public string value;


        private void Reset()
        {
            Name = "Parameter: At"; // � ��������� ���������� single
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(value))
            {
                return GetTestValue();
            }
            return null;
        }

        public override object GetTestValue()
        {
            FlowNodeGraph flowGraph = graph as FlowNodeGraph;
            if (flowGraph != null && at >= 0 && at < flowGraph.FlowParameters.Length)
            {
                return flowGraph.FlowParameters[at];
            }
            else
                return null;
        }
    }
}
