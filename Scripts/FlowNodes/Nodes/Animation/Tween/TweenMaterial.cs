using UnityEngine;
using TMPro;

namespace XMonoNode
{
    public abstract class TweenMaterial<Val> : TweenObjectValue<Material, Val>
    {
        [Input(connectionType: ConnectionType.Override)]
        public string paramName;

        private NodePort namePort;

        public NodePort NamePort => namePort;

        protected override void Init()
        {
            base.Init();

            namePort = GetInputPort(nameof(paramName));
        }

    }
}
