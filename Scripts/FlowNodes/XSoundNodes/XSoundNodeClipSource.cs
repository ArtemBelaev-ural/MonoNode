using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Нода-источник звуков. Может воспроизводить AudioClip
    /// </summary>
    [AddComponentMenu("X Sound Node/ClipSource", 1)]
    [CreateNodeMenu("Sound/ClipSource", 1)]
    [NodeWidth(240)]
    [NodeTint(70, 100, 70)]
    public class XSoundNodeClipSource : XSoundNodeBase
    {
        [Input(connectionType: ConnectionType.Override)]
        public AudioClip clip = null;

        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)] 
        public AudioSources audioOutput;

        private void Reset()
        {
            Name = "Clip Audio Source";
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(audioOutput)) 
            {
                if (audioOutput == null)
                {
                    audioOutput = new AudioSources();
                }

                audioOutput.List.Clear();

                if (port.ConnectionCount == 0)
                {
                    return audioOutput;
                }

                IXSoundsLibrary sounds = IXSoundsLibraryInstance.Get();

                clip = GetInputValue(nameof(clip), clip);

                if (clip == null)
                {
                    Debug.LogErrorFormat(this, "The audio clip is not defined! {0} ({1})".Color(Color.magenta), gameObject.name, Name);
                    return audioOutput;
                }

                AudioSource source = sounds.Play(clip);

                if (source != null)
                {
                    audioOutput.List.Add(source);
                }
                else
                {
                    Debug.LogErrorFormat("Attempt to play the sound '{0}' failed".Color(Color.magenta), name);
                }

                return audioOutput;
            }

            return null;
        }
    }
}
