using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace FlowNodes
{
    /// <summary>
    /// Изменяет свойство pitch
    /// </summary>
    [AddComponentMenu("X Sound Node/Pitch", 53)]
    [CreateNodeMenu("Sound/Pitch", 53)]
    [NodeWidth(160)]
    public class XSoundNodePitch : FlowNode
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

        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)]
        public AudioSources audioOutput;

        [Input(connectionType: ConnectionType.Override, typeConstraint: TypeConstraint.Inherited)]
        public float                    pitch = 1.0f;

        private void Reset()
        {
            Name = "Pitch";
        }

        public override void ExecuteNode()
        {
            changePitch();
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(audioOutput))
            {
                return changePitch();
            }
            else
                return null;
        }

        private object changePitch()
        {
            pitch = GetInputValue(nameof(pitch), pitch);

            AudioSources sources = GetAudioInput();
            foreach (AudioSource source in sources.List)
            {
                source.pitch = pitch;
            }
            return sources;
        }
    }
}
