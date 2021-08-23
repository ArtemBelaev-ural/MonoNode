using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    public abstract class AnimateValue : FlowNodeInOut
    {
        public enum State
        {
            Stopped = 0,
            Started = 1,
        }

        public abstract System.Type Type
        {
            get;
        }

        public override void TriggerFlow()
        {
            //base.TriggerFlow(); 
        }
    }

    public abstract class AnimateValue<T> : AnimateValue
    {
        [Inline]
        [Input(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.None), NodeInspectorButton]
        public Flow stop;

        [Output(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.None), NodeInspectorButton]
        public Flow tick;

        [Output]
        public T value;

        [Input(connectionType: ConnectionType.Override)]
        public T from = default(T);

        [Input(connectionType: ConnectionType.Override)]
        public T to = default(T);

        [Input(connectionType: ConnectionType.Override)]
        public float duration = 1;

        [SerializeField, NodeEnum]
        private EasingMode      easingMode = EasingMode.Linear;

        public EasingMode EasingMode
        {
            get => easingMode;
            set => easingMode = value;
        }

        public override System.Type Type => typeof(T);

        public NodePort StopPort => stopPort;
        public NodePort TickPort => tickPort;

        public NodePort FromPort  => fromPort;
        public NodePort ToPort => toPort;
        public NodePort DurationPort  => durationPort;

        private NodePort stopPort;
        private NodePort tickPort;

        private NodePort valuePort;
        private NodePort fromPort;
        private NodePort toPort;
        private NodePort durationPort;

        private float remainingSec = 0.0f;

        private State state = State.Stopped;

        protected override void Init()
        {
            base.Init();

            stopPort = GetInputPort(nameof(stop));
            tickPort = GetOutputPort(nameof(tick));

            fromPort = GetInputPort(nameof(from));
            toPort = GetInputPort(nameof(to));
            durationPort = GetInputPort(nameof(duration));
            valuePort = GetOutputPort(nameof(value));

            FlowInputPort.label = "Start";
            FlowOutputPort.label = "Completed";

            durationPort.label = "Duration (sec)";
        }

        public override void Flow(NodePort flowPort) 
        {
            if (flowPort == FlowInputPort)
            {
                StartTimer();
            }
            else if (flowPort == stopPort)
            {
                StopTimer();
            }
        }

        public override object GetValue(NodePort port) 
        {
            if (port == valuePort)
            {
                return value;
            }

            return null;
        }

        public override void Stop()
        {
            StopTimer();
        }

        private void Update()
        {
            if (state == State.Started)
            {
                TickTimer();
            }
        }

        private void StartTimer()
        {
            state = State.Started;
            FlowUtils.FlowOutput(tickPort);
            duration = durationPort.GetInputValue(duration);
            remainingSec = duration;
            from = fromPort.GetInputValue(from);
            to = toPort.GetInputValue(to);
            value = to;
        }

        private void StopTimer()
        {
            if (state == State.Started)
            {
                state = State.Stopped;
            }
        }

        protected abstract T GetValue(float tNormal);

        private void TickTimer()
        {
            remainingSec -= Time.deltaTime;
            FlowUtils.FlowOutput(tickPort);
            if (remainingSec <= 0.0f || duration <= 0f)
            {
                TimerCompleted();
                return;
            }
            value = GetValue(FloatEase.Ease((duration - remainingSec) / duration, EasingMode));
        }

        private void TimerCompleted()
        {
            value = to;
            remainingSec = 0f;
            state = State.Stopped;
            FlowUtils.FlowOutput(FlowOutputPort);
        }
    }
}
