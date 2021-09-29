using UnityEngine;
using System.Collections.Generic;

namespace XMonoNode
{
    /// <summary>
    /// Fades the sound
    /// </summary>
    [AddComponentMenu("X Sound Node/Fade In", 310)]
    [CreateNodeMenu("Sound/Fade In", 310)]
    [NodeWidth(180)]
    public class XSoundNodeFadeIn : FlowNodeInOut
    {
        [Inline]
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited, backingValue: ShowBackingValue.Never)]
        public AudioSources input = new AudioSources();

        [Output(typeConstraint: TypeConstraint.Inherited)]
        public AudioSources output = new AudioSources();

        [SerializeField, NodeEnum, HideInNodeInspector]
        private EasingMode      easingMode = EasingMode.Linear;

        [Input(connectionType: ConnectionType.Override), Range(0f, 60f)]
        public float duration = 1f;

        [Input(connectionType: ConnectionType.Override), Range(0f, 1f)]
        public float volume = 1f;

        [Inline]
        [Input(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.None), NodeInspectorButton, Hiding]
        public Flow stop;

        [Output, NodeInspectorButton, Hiding]
        public Flow completed;

        public EasingMode EasingMode
        {
            get => easingMode;
            set => easingMode = value;
        }

        public XSoundNodeGraph SoundGraph => graph as XSoundNodeGraph;

        public NodePort StopPort => stopPort;
        public NodePort CompletedPort => completedPort;

        public NodePort DurationPort => durationPort;

        public enum State
        {
            Stopped = 0,
            Started = 1,
        }

        private AudioSources playing = new AudioSources();

        private NodePort outputPort;
        private NodePort stopPort;
        private NodePort completedPort;
        private NodePort durationPort;
        private NodePort volumePort;
        private float remainingSec = 0.0f;

        private State state = State.Stopped;

        private void Reset()
        {
            Name = "Fade In";
        }

        protected override void Init()
        {
            base.Init();

            outputPort = GetOutputPort(nameof(output));
            stopPort = GetInputPort(nameof(stop));
            completedPort = GetOutputPort(nameof(completed));
            durationPort = GetInputPort(nameof(duration));
            volumePort = GetInputPort(nameof(volume));

            FlowInputPort.label = "Start";
            FlowOutputPort.label = "Started";

            durationPort.label = "Duration (sec)";
        }

        public override object GetValue(NodePort port)
        {
            if (port == outputPort)
            {
                return playing;
            }
            else
            {
                return null;
            }
        }

        public override void Flow(NodePort flowPort)
        {
            if (flowPort == FlowInputPort)
            {
                StartTimer();
            }
            else if (flowPort == StopPort)
            {
                Stop();
            }
        }
        public override void Stop()
        {
            if (state == State.Started)
            {
                remainingSec = 0f;
                state = State.Stopped;
                playing.List.Clear();
            }
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
            AudioSources sources = GetInputValue<AudioSources>(nameof(input));
            playing.List.AddRange(sources.List);

            state = State.Started;
            duration = durationPort.GetInputValue(duration);
            volume = volumePort.GetInputValue(volume);
            remainingSec = duration;

            foreach (AudioSource source in playing.List)
            {
                if (source != null)
                {
                    source.volume = 0f;
                }
            }
            FlowOut(); // Started

            if (Mathf.Approximately(duration, 0f) || duration < 0f)
            {
                TimerCompleted();
            }
        }

        private void TickTimer()
        {
            remainingSec -= Time.deltaTime;
            if (remainingSec <= 0.0f || duration <= 0f)
            {
                TimerCompleted();
                return;
            }

            float fade = FloatEase.Ease((duration - remainingSec) / duration, EasingMode);
            foreach (AudioSource source in playing.List)
            {
                if (source != null && source.isPlaying)
                {
                    source.volume = fade * volume;
                }
            }
        }

        private void TimerCompleted()
        {
            foreach (AudioSource source in playing.List)
            {
                if (source != null)
                {
                    source.volume = volume;
                }
            }
            Stop();
            FlowUtils.FlowOutput(completedPort);
        }
    }

}
