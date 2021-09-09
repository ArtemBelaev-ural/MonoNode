using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// �����. ������������ �������� ����, ���������� �� ������������ ������
    /// </summary>
    [AddComponentMenu("X Sound Node/Play", 5)]
    [CreateNodeMenu("Sound/Play", 5)]
    [NodeTint(105, 65, 65)]
    [NodeWidth(150)]
    [ExecuteInEditMode]
    public class XSoundNodePlay : FlowNodeInOut
    {
        [Output, NodeInspectorButton] public Flow whilePlay;
        
        [Inline]
        [Input(backingValue: ShowBackingValue.Never), NodeInspectorButton] public Flow stop;
        [Output, NodeInspectorButton] public Flow onEnd;

        [Inline]
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited, backingValue: ShowBackingValue.Never)]
        public AudioSources audioInput = new AudioSources();
        [Output(typeConstraint: TypeConstraint.Inherited)]
        public AudioSources Playing;

        public XSoundNodeGraph SoundGraph => graph as XSoundNodeGraph;

        public object[] PlayParameters => SoundGraph?.FlowParametersArray;

        private AudioSources playing;

        // ��������������� �������, ����������� ����������, ��� ���� ��������� ���� ����
        private bool playingState = false;

        protected NodePort stopPort;

        protected NodePort wnilePlayPort;
        protected NodePort onEndPort;

        public AudioSources PlayingSources()
        {
            return playing;
        }

        public override void Flow(NodePort flowPort)
        {
            if (flowPort == FlowInputPort)
            {
                Play(PlayParameters);
            }
            else if (flowPort == stopPort)
            {
                Stop();
            }
        }

        public override void TriggerFlow()
        {
            // �� �������� base.TriggerFlow() - ��� �������� � ����������� ��������
        }

        private void Reset()
        {
            Name = "Play";
        }

        public XSoundNodePlay()
        {
            playing = new AudioSources();
        }

        protected override void Init()
        {
            base.Init();

            // ��� �������� ������� ������� � ����������� flow ������

            FlowInputPort.label = "Play";
            FlowOutputPort.label = "On Start";

            stopPort = GetInputPort(nameof(stop));

            wnilePlayPort = GetOutputPort(nameof(whilePlay));
            onEndPort = GetOutputPort(nameof(onEnd));

            GetInputPort(nameof(audioInput)).label = "Input";
            
        }

        private void Update()
        {
            if (SourcesIsPlaying) // ��� ������������� ������
            {
                TriggerWhilePlay();
            }
            else if (playing.List.Count != 0) // ���� ����������
            {
                playingState = false;
                TriggerOnEnd();
                if (SourcesIsPlaying == false) // �� ���� ������� ���������� �� ������� ����� (���� ��������� ���� ����� ����� ���� ����)
                {
                    if (Application.isPlaying == false)
                    {
                        playing.DestroySourcesIfStopped();
                    }
                }
                if (!playingState) // ���� ���� �� ��������� ���� ����, ������� ������
                {
                    playing.List.RemoveAll(s => s == null || s.loop == false); // ������ ������� loop �����, �.�. stop ����� ���� ������ unity ��� �������� � ������ ����
                }
            }
        }

        public void Play(params object[] parameters)
        {
            playingState = true;
            TriggerOnStart();

            if (SoundGraph != null)
            {
                SoundGraph.FlowParametersArray = parameters;
            }

            AudioSources sources = GetInputValue<AudioSources>(nameof(audioInput));
            if (sources == null) // ������ ����� - ������. ������ ��������� (sources.List.Count == 0) - ��� ���������
            {
                Debug.LogErrorFormat(this, "An audio source is not attached to the Play node {0} ({1})".Color(Color.magenta), gameObject.name, Name);
                return;
            }

            foreach (AudioSource source in sources.List)
            {
                if (source == null)
                {
                    continue;
                }

                source.Play();
            }
            
            if (Application.isPlaying == false)
            {// � ������ ��������� �� ������� �� �������� �����
                playing.List.ForEach(s => { if (s != null && !s.isPlaying) DestroyImmediate(s.gameObject); });
            }

            // ������� ���, ����� �����������
            playing.List.RemoveAll(s => s == null || (!s.loop && !s.isPlaying));
            
            playing.List.AddRange(sources.List);
        }

        [ContextMenu("Play")]
        public void TestPlay()
        {
            FlowNodeGraph flowGraph = graph as FlowNodeGraph;
            if (flowGraph != null)
            {
                if (Application.isPlaying == false)
                {
                    flowGraph.Stop();
                }
                flowGraph.UpdateTestParameters();
                Play(flowGraph.FlowParametersArray);
            }
        }

        [ContextMenu("Stop")]
        public override void Stop()
        {
            playingState = false;
            playing.Stop();
            if (Application.isPlaying == false)
            {
                playing.DestroySourcesIfStopped();
            }
            playing.DestroySourcesIfLoop();
            playing.List.Clear();
        }

        public bool SourcesIsPlaying => playing.IsPlaying;


        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Playing))
            {
                return PlayingSources();
            }
            else
            {
                return null;
            }
        }

        private void TriggerOnStart()
        {
            FlowUtils.FlowOutput(FlowOutputPort);
        }

        private void TriggerWhilePlay()
        {
            FlowUtils.FlowOutput(wnilePlayPort);
        }

        private void TriggerOnEnd()
        {
            FlowUtils.FlowOutput(onEndPort);
        }

    }
}
