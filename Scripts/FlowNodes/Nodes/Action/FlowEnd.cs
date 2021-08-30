using UnityEngine.Events;
using XMonoNode;
using UnityEngine;

namespace XMonoNode
{

    [CreateNodeMenu("Action/FlowEnd", 13)]
    [NodeTint(40, 60, 105)]
    [NodeWidth(100)]
    public class FlowEnd : FlowNodeIn
    {
        

        public System.Action<string> Action
        {
            get;
            set;
        }

        private void Reset()
        {
            Name = "FlowEnd";
        }

        public override void Flow(NodePort flowPort)
        {
            if (Action != null)
            {
                FlowNodeGraph flowGraph = graph as FlowNodeGraph;
                Action.Invoke(flowGraph != null ? flowGraph.State : "");
            }
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}
