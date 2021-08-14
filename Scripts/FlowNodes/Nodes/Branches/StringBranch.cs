using XMonoNode;

namespace XMonoNode
{
    [NodeWidth(250)]
    [CreateNodeMenu("Branch/" + nameof(StringBranch), 18)]
    public class StringBranch : FlowNode
    {
        [Input] public string StringTrue;
        
        [Output] public Flow FalseOutput;
        [Input] public string StringFalse;

        private NodePort portOutFalse;

        public override void OnNodeEnable()
        {
            base.OnNodeEnable();

            portOutFalse = GetOutputPort(nameof(FalseOutput));

            // Для удобства изменим подпись к стандартным flow портам

            flowOutputPort.label = "True";
            portOutFalse.label = "False";
        }

        public override void TriggerFlow()
        {
            var stringA = GetInputValue(nameof(StringTrue), StringTrue);
            var stringB = GetInputValue(nameof(StringFalse), StringFalse);

            FlowUtils.TriggerFlow(stringA == stringB ? flowOutputPort : portOutFalse);
        }

        public override void Flow(NodePort flowPort)
        {
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
