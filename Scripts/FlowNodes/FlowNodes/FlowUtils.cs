using System.Collections.Generic;
using XMonoNode;
using UnityEngine;

namespace XMonoNode
{
    public static class FlowUtils
    {
        public static void TriggerFlow(NodePort output)
        {
            var connectedInputPorts = new List<NodePort>();
            
            for (int i = 0; i < output.ConnectionCount; ++i)
            {
                var inputPort = output.GetConnection(i);
                if (inputPort.ValueType == typeof(Flow))
                {
                    connectedInputPorts.Add(inputPort);
                    var flowNode = inputPort.node as FlowNode;
                    if (flowNode != null)
                    {
                        flowNode.Flow(inputPort);
                    }
                }
            }

            for (int i = 0; i < connectedInputPorts.Count; i++)
            {
                var flowNode = connectedInputPorts[i].node as FlowNode;
                if (flowNode != null)
                {
                    flowNode.TriggerFlow();
                }
            }
        }
    }
}