using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Нода-источник звуков. Может воспроизводить soundId или заданные источники звуков
    /// </summary>
    [AddComponentMenu("X Sound Node/Source", 0)]
    [CreateNodeMenu("Sound/Source", 0)]
    [NodeWidth(300)]
    [NodeTint(70, 100, 70)]
    public class XSoundNodeSource : XSoundNodeBase
    {
        [XSoundSelector]
        [SerializeField]
        private int                 soundId = -1;

        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.Inherited)] 
        public AudioSources audioOutput;
      
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
   
                if (soundId == -1)
                {
                    Debug.LogErrorFormat(this, "Лёха!!! У ноды сурса звука id -1! {0} ({1})".Color(Color.magenta), gameObject.name, Name);
                    return audioOutput;
                }

                AudioSource source = sounds.Play(soundId, PlayParameters);

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
            else
            {
                return null;
            }
        }
    }
}
