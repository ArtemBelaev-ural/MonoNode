using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Изменяет свойство loop
    /// </summary>
    [AddComponentMenu("X Sound Node/Loop", 202)]
    [CreateNodeMenu("Sound/Loop", 202)]
    [NodeWidth(130)]
    public class XSoundNodeLoop : XSoundNodeSimpleOutput
    {
        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited), Hiding]
        public bool                    loop = true;

        private void Reset()
        {
            Name = "Loop";
        } 

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(audioOutput))
            {
                loop = GetInputValue(nameof(loop), loop);

                AudioSources sources = GetAudioInput();
                foreach (AudioSource source in sources.List)
                {
                    source.loop = loop;
                }
                return sources;
            }

            return null;
        }
    }
}
