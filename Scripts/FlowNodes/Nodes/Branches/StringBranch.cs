using XMonoNode;

namespace XMonoNode
{
    [NodeWidth(250)]
    [CreateNodeMenu("Branch/" + nameof(StringBranch), 12)]
    public class StringBranch : FlowNode
    {
        [Input] public string StringTrue;
        
        [Output] public Flow FalseOutput;
        [Input] public string StringFalse;

        public override void OnEnable()
        {
            base.OnEnable();
            // Для удобства изменим подпись к стандартным flow портам

            NodePort portOut = GetOutputPort(nameof(FlowOutput));
            if (portOut != null)
            {
                portOut.label = "True";
            }

            NodePort portOutFalse = GetOutputPort(nameof(FalseOutput));
            if (portOut != null)
            {
                portOutFalse.label = "False";
            }
        }

        public override void TriggerFlow()
        {
            var stringA = GetInputValue<string>(nameof(StringTrue), StringTrue);
            var stringB = GetInputValue<string>(nameof(StringFalse), StringFalse);
            var outputTriggerName = stringA == stringB ? nameof(FlowNode.FlowOutput) : nameof(FalseOutput);
            FlowUtils.TriggerFlow(Outputs, outputTriggerName);
        }

        public override void Flow()
        {
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
