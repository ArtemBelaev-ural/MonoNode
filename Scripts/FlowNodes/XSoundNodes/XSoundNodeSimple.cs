using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// Базовый класс для нодов, принимающих один источник звука
    /// </summary>
    public abstract class XSoundNodeSimple : XSoundNodeBase
    {
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited)]
        public AudioSources audioInput;

        protected AudioSources GetAudioInput()
        {
            AudioSources sources = GetInputValue(nameof(audioInput), audioInput);
            if (sources == null)
            {
                sources = new AudioSources();
            }
            return sources;
        }
    }

    public abstract class XSoundNodeSimpleOutput : XSoundNodeSimple
    {
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)]
        public AudioSources audioOutput;
    }
}