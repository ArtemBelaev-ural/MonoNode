using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ¬озвращает положение источника звука
    /// </summary>
    [AddComponentMenu("X Sound Node/GetSourcePos", 221)]
    [CreateNodeMenu("Sound/GetSourcePos", 221)]
    [NodeWidth(150)]
    public class XSoundNodeGetSourcePos: XSoundNodeSimple
    {
        [Output]
        public Vector3  sourcePosition;

        private void Reset()
        {
            Name = "Source Pos";
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(sourcePosition))
            {
                AudioSources sources = GetAudioInput();
                return sources.List.Count != 0 ? sources.List[0].gameObject.transform.position : Vector3.zero;
            }
            return null;
        }
    }
}
