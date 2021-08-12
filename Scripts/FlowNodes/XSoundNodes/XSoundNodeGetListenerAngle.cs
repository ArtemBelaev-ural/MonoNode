using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает угол между осью oz камеры и инаправлением от камеры на источник звука
    /// </summary>
    [AddComponentMenu("X Sound Node/GetListenerAngle", 225)]
    [CreateNodeMenu("Sound/GetListenerAngle", 225)]
    [NodeWidth(150)]
    public class XSoundNodeGetListenerAngle: XSoundNodeSimple
    {
        [Output]
        public float  listenerAngle;
        [Input]
        public bool normalized = true;

        private void Reset()
        {
            Name = "Listener Angle";
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(listenerAngle))
            {
                AudioSources sources = GetAudioInput();

                float angle = 0.0f;
                if (sources.List.Count != 0)
                {
                    AudioSource source = sources.List[0];
                    Transform cameraTransform = Camera.main.transform;
                    angle = Vector3.Angle(source.transform.position - cameraTransform.position, cameraTransform.forward);
                    if (GetInputValue(nameof(normalized), normalized))
                    {
                        angle /= 180.0f;
                    }
                }
                return angle;
            }

            return null;
        }
    }
}
