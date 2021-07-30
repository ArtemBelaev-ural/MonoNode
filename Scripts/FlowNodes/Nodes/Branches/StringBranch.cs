using XMonoNode;

namespace XMonoNode
{
    [NodeWidth(250)]
    [CreateNodeMenu("Branch/" + nameof(StringBranch), 12)]
    public class StringBranch : FlowNode
    {
        [Input] public string StringA;
        [Input] public string StringB;
        [Output] public Flow FalseOutput;

        public override void TriggerFlow()
        {
            var stringA = GetInputValue<string>(nameof(StringA), StringA);
            var stringB = GetInputValue<string>(nameof(StringB), StringB);
            var outputTriggerName = stringA == stringB ? nameof(FlowNode.FlowOutput) : nameof(FalseOutput);
            FlowUtils.TriggerFlow(Outputs, outputTriggerName);
        }

        public override void ExecuteNode()
        {
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
