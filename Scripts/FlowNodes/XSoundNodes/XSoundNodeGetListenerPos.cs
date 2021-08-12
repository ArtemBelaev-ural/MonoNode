using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Возвращает
    /// </summary>
    [AddComponentMenu("X Sound Node/GetListenerPos", 222)]
    [CreateNodeMenu("Sound/GetListenerPos", 222)]
    [NodeWidth(150)]
    public class XSoundNodeGetListenerPos : MonoNode
    {
        [Output]
        public Vector3  listenerPosition;

        private void Reset()
        {
            Name = "Listener Position";
        }

        public override object GetValue(NodePort port)
        {
            return Camera.main.transform.position;
        }
    }
}
