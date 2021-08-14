using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Изменяет свойство volume
    /// </summary>
    [AddComponentMenu("X Sound Node/Volume", 52)]
    [CreateNodeMenu("Sound/Volume", 52)]
    [NodeWidth(160)]
    public class XSoundNodeVolume : FlowNode
    {
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited)]
        public AudioSources audioInput;

        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)]
        public AudioSources audioOutput;

        [Input(connectionType: ConnectionType.Override)]
        [Range(0.0f, 1.0f)]
        public float                    volume = 1.0f;

        private AudioSources GetAudioInput()
        {
            AudioSources sources = GetInputValue(nameof(audioInput), audioInput);
            if (sources == null)
            {
                sources = new AudioSources();
            }
            return sources;
        }

        private void Reset()
        {
            Name = "Volume";
        }

        public override void Flow(NodePort flowPort)
        {
            changeVolume();
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(audioOutput))
            {
                return changeVolume();
            }
            else
                return null;
        }

        private object changeVolume()
        {
            volume = GetInputValue(nameof(volume), volume);

            AudioSources sources = GetAudioInput();
            foreach (AudioSource source in sources.List)
            {
                source.volume = volume;
            }
            return sources;
        }
    }
}
