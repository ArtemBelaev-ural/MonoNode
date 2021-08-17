using XMonoNode;

namespace XMonoNode
{
    public abstract class FlowNode : MonoNode, IFlowNode
    {
        [Input(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.None), NodeInspectorButton]
        public Flow FlowInput;

        [Output(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.None), NodeInspectorButton]
        public Flow FlowOutput;

        private NodePort flowInputPort;
        private NodePort flowOutputPort;

        public NodePort FlowInputPort
        {
            get => flowInputPort;
            set => flowInputPort = value;
        }
        public NodePort FlowOutputPort
        {
            get => flowOutputPort;
            set => flowOutputPort = value;
        }

        protected override void Init()
        {
            base.Init();

            FlowInputPort = GetInputPort(nameof(FlowInput));
            FlowOutputPort = GetOutputPort(nameof(FlowOutput));

        }

        public virtual void TriggerFlow()
        {
            FlowUtils.TriggerFlow(FlowOutputPort);
        }

        /// <summary>
        /// Handle input stream
        /// </summary>
        public abstract void Flow(NodePort flowPort);

        /// <summary>
        /// Stop execution of this flow node
        /// </summary>
        public virtual void Stop()
        {

        }


    }
}
