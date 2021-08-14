using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ѕлеер. ќб€зательна€ конечна€ нода, отвечающа€ за проигрывание звуков
    /// </summary>
    [AddComponentMenu("X Sound Node/Play", 1)]
    [CreateNodeMenu("Sound/Play", 1)]
    [NodeTint(105, 65, 65)]
    [NodeWidth(180)]
    [ExecuteInEditMode]
    public class XSoundNodePlay : FlowNode
    {
        [Output] public Flow whilePlay;
        [Output] public Flow onEnd;

        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited, backingValue: ShowBackingValue.Never)]
        public AudioSources audioInput = new AudioSources();
        [Output(typeConstraint: TypeConstraint.Inherited)]
        public AudioSources Playing;

        public XSoundNodeGraph SoundGraph => graph as XSoundNodeGraph;

        public object[] PlayParameters => SoundGraph?.FlowParametersArray;

        private AudioSources playing = new AudioSources();

        // ¬спомогательный признак, позвол€ющий определить, что нода запустила сама себ€
        private bool playingState = false;

        protected NodePort wnilePlayPort;
        protected NodePort onEndPort;

        public override void Flow(NodePort flowPort)
        {
            if (flowPort == flowInputPort)
            {
                Play(PlayParameters);
            }
        }

        public override void TriggerFlow() // „тобы поток продолжалс€ только когда звук завершитс€
        {
            // не вызывать base.TriggerFlow() - это приведет к бесконечной рекурсии
        }

        private void Reset()
        {
            Name = "Play";
        }

        public override void OnNodeEnable()
        {
            base.OnNodeEnable();

            // ƒл€ удобства изменим подпись к стандартным flow портам

            flowInputPort.label = "Play";
            flowOutputPort.label = "On Start";

            wnilePlayPort = GetOutputPort(nameof(whilePlay));
            onEndPort = GetOutputPort(nameof(onEnd));
        }

        private void Update()
        {
            if (SourcesIsPlaying) // зук проигрываетс€ сейчас
            {
                TriggerWhilePlay();
            }
            else if (playing.List.Count != 0) // звук завершилс€
            {
                playingState = false;
                TriggerOnEnd();
                if (SourcesIsPlaying == false) // не даем удалить запущенные по цепочке звуки (если следующа€ нода вз€ла звуки этой ноды)
                {
                    if (Application.isPlaying == false)
                    {
                        playing.DestroySourcesIfStopped();
                    }
                }
                if (!playingState) // если нода не запустила сама себ€, очищаем список
                {
                    playing.List.RemoveAll(s => s == null || s.loop == false); // нельз€ удал€ть loop звуки, т.к. stop может быть вызван unity при переходе в другое окно
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

            AudioSources sources = GetInputValue<AudioSources>(nameof(audioInput), audioInput);
            if (sources == null) // только нуллы - ошибка. ѕустой контейнер (sources.List.Count == 0) - это нормально
            {
                Debug.LogErrorFormat(this, "ЋЄха!!! ” ноды play не задан источник! {0} ({1})".Color(Color.magenta), gameObject.name, Name);
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
            {// ¬ режиме редактора мы удал€ем не играющие звуки
                playing.List.ForEach(s => { if (s != null && !s.isPlaying) DestroyImmediate(s.gameObject); });
            }

            // ”дал€ем все, кроме зацикленных
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
            playing.List.Clear();
        }

        public bool SourcesIsPlaying => playing.IsPlaying;


        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Playing))
            {
                return playing;
            }
            else
            {
                return null;
            }
        }

        private void TriggerOnStart()
        {
            FlowUtils.TriggerFlow(flowOutputPort);
        }

        private void TriggerWhilePlay()
        {
            FlowUtils.TriggerFlow(wnilePlayPort);
        }

        private void TriggerOnEnd()
        {
            FlowUtils.TriggerFlow(onEndPort);
        }

    }
}
