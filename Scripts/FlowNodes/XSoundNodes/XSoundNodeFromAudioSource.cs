using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Ќода-источник звуков. ћожет воспроизводить soundId или заданные источники звуков
    /// </summary>
    [CreateNodeMenu("Sound/Audio Source", 2)]
    [NodeWidth(180)]
    [NodeTint(70, 100, 70)]
    public class XSoundNodeFromAudioSource : XSoundNodeBase
    {
        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)]
        public AudioSources audioOutput;

        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.InheritedAny), HideLabel]
        public AudioSource source;

        private void Reset()
        {
            Name = "Audio Source";
        }

        public override object GetValue(NodePort port)
        {
            return new AudioSources(new List<AudioSource>() { Instantiate(GetInputValue(nameof(source), source)) });
        }
    }
}
