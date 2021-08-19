using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Базовый класс для нодов, принимающих один источник звука
    /// </summary>
    public abstract class XSoundNodeSimple : XSoundNodeBase
    {
        [Inline]
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited, backingValue: ShowBackingValue.Never)]
        public AudioSources audioInput;

        protected override void Init()
        {
            base.Init();

            GetInputPort(nameof(audioInput)).label = "Input";
        }

        protected AudioSources GetAudioInput()
        {
            AudioSources sources = GetInputValue<AudioSources>(nameof(audioInput));
            if (sources == null)
            {
                sources = new AudioSources();
            }
            return sources;
        }
    }

    public abstract class XSoundNodeSimpleOutput : XSoundNodeBase
    {
        [Inline]
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited, backingValue: ShowBackingValue.Never)]
        public AudioSources audioInput;
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)]
        public AudioSources audioOutput;

        protected override void Init()
        {
            base.Init();

            GetInputPort(nameof(audioInput)).label = "Input";
            GetOutputPort(nameof(audioOutput)).label = "Output";
        }

        protected AudioSources GetAudioInput()
        {
            AudioSources sources = GetInputValue<AudioSources>(nameof(audioInput));
            if (sources == null)
            {
                sources = new AudioSources();
            }
            return sources;
        }
    }
}