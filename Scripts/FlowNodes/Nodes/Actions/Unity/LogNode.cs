using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Utils/Log", 1)]
    public class LogNode : FlowNode 
    {
        [Input] public string Text;

        public override void ExecuteNode() 
        {
            NodePort port = GetInputPort(nameof(Text));
            int count = port.ConnectionCount;

            if (count == 0)
            {
                Debug.LogFormat("<color=brown>{0}: </color>" + Text, Name);
            }
            else if (count == 1)
            {
                Debug.LogFormat("<color=brown>{0}: </color>" + port.GetInputValue<object>(), Name);
            }
            else
            {
                Debug.LogFormat("<color=brown>{0} ({1} inputs):</color>", Name, count);
                for (int i = 0; i < count; ++i)
                {
                    object[] input = port.GetInputValues();
                    Debug.LogFormat("<color=brown>{0}) </color>" + input[i], i);
                }
            }
        }

        public override object GetValue(NodePort port) 
        {
            return null;
        }
    }
}
