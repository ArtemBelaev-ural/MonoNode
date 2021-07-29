using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// ¬оспроизводит звук, расположенный не далее distance
    /// </summary>
    [AddComponentMenu("X Sound Node/Mixer", 206)]
    [CreateNodeMenu("Sound/Mixer", 206)]
    [NodeWidth(270)]
    public class XSoundNodeMixer : XSoundNodeSimpleOutput
    {
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited)]
        public AudioMixerGroup audioMixerGroup = null;

        private void Reset()
        {
            Name = "Mixer";
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(audioOutput))
            {
                audioMixerGroup = GetInputValue("audioMixerGroup", audioMixerGroup);

                AudioSources sources = GetAudioInput();
                foreach (AudioSource source in sources.List)
                {
                    source.outputAudioMixerGroup = audioMixerGroup;
                }
                return sources;
            }

            return null;
        }
    }
}
