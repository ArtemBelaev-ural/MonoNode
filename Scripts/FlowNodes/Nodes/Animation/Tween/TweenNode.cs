#if DOTWEEN_SUPPORTED
using UnityEngine;

namespace XMonoNode
{
    public abstract class TweenNode : FlowNodeInOut
    {
        public enum LoopType
        {
            Restart = 0,
            Yoyo = 1,
            Incremental = 2
        }

        public enum State
        {
            Stopped = 0,
            Wait = 1,
            Started = 2,
        }

        public State state => _state;
        private State _state = State.Stopped;

        [Input(connectionType: ConnectionType.Override)]
        public float duration = 1f;

        [Input(connectionType: ConnectionType.Override)]
        public float delay = 0f;

        [Input(connectionType: ConnectionType.Override)]
        public int loopsAmount;

        [NodeEnum]
        public LoopType loop = LoopType.Restart;

        [NodeEnum]
        public EasingMode easingMode = EasingMode.Linear;


        protected abstract void OnTweenStart();

        protected abstract void OnTweenTick(float tNormal);

        protected abstract void OnTweenEnd();

        protected abstract void OnNextLoop(LoopType loopType);

        private float remainingSec = 0.0f;
        private float waitRemainingSec = 0.0f;
        private int loopsCount = 0;

        protected override void Init()
        {
            base.Init();

            GetInputPort(nameof(duration)).label = "Duration (sec)";
            GetInputPort(nameof(delay)).label = "Delay (sec)";
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }

        public override void TriggerFlow()
        {
            //base.TriggerFlow();
        }

        public override void Flow(NodePort flowPort)
        {
            if (flowPort == FlowInputPort && state == State.Stopped)
            {
                StartTimer();
            }
        }

        private void Update()
        {
            if (state != State.Stopped)
            {
                TickTimer();
            }
        }

        private void StartTimer()
        {
            duration = GetInputValue(nameof(duration), duration);
            if (duration <= 0.0f)
            {
                return;
            }

            delay = GetInputValue(nameof(delay), delay);
            loopsAmount = GetInputValue(nameof(loopsAmount), loopsAmount);
            waitRemainingSec = delay;
            remainingSec = duration;
            
            loopsCount = 0;

            if (waitRemainingSec > 0.0f)
            {
                _state = State.Wait;
            }
            else
            {
                _state = State.Started;
                OnTweenStart();
            }
        }

        private void TickTimer()
        {
            if (state == State.Wait)
            {
                waitRemainingSec -= Time.deltaTime;
                if (waitRemainingSec <= 0.0f)
                {
                    _state = State.Started;
                   // remainingSec += waitRemainingSec; // погрешность
                    OnTweenStart();
                }
            }

            if (state == State.Started)
            {
                remainingSec -= Time.deltaTime;
                if (remainingSec <= 0.0f)
                {
                    ++loopsCount;
                    OnNextLoop(loop);
                    if (loopsCount == loopsAmount || loopsAmount == 0)  // stop
                    {
                        FlowUtils.FlowOutput(FlowOutputPort);
                        remainingSec = 0.0f;
                        _state = State.Stopped;
                        OnTweenEnd();
                        return;
                    }
                    else // next loop
                    {
                        remainingSec = duration;// + remainingSec; // начинаем отсчет сначала (+погрешность)
                    }
                }

                float time = (duration - remainingSec) / duration; // время [0..1]

                if (loop == LoopType.Yoyo && (loopsCount % 2) == 1) // время в обратную сторону
                {
                    time = 1.0f - time;
                }

                OnTweenTick(FloatEase.Ease(time, easingMode));
            }
        }



    }
}
#endif
