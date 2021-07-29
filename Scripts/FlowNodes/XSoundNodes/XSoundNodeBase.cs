using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Set of AudioSource flowing in node graph
    /// </summary>
    [System.Serializable]
    public class AudioSources
    {
        [SerializeField]
        private List<AudioSource> list = new List<AudioSource>();

        public List<AudioSource> List => list;

        public void Stop()
        {
            foreach (AudioSource source in list)
            {
                if (!source)
                    continue;
                source.Stop();
            }
        }

        public void DestroySourcesIfStopped()
        {
            if (IsPlaying)
            {
                return;
            }

            foreach (AudioSource source in list)
            {
                if (source == null)
                    continue;
                Object.DestroyImmediate(source.gameObject);
            }
            list.Clear();
        }

        public bool IsPlaying 
        {
            get
            {
                foreach (AudioSource source in list)
                {
                    if (source != null && source.isPlaying)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public AudioSources()
        {
            this.list = new List<AudioSource>();
        }

        public AudioSources(List<AudioSource> list)
        {
            this.list = list;
        }

    }

    /// <summary>
    /// Базовый класс звуковых нодов
    /// </summary>
    public abstract class XSoundNodeBase : MonoNode
    {
        public XSoundNodeGraph      SoundGraph => graph as XSoundNodeGraph;

        public object[]             PlayParameters => SoundGraph?.ExecuteParameters;

        public override object GetValue(NodePort port)
        {
            return null;
        }

    }
}
