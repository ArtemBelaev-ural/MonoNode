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

        protected int Id
        {
            get;
            set;
        }

        protected string Name
        {
            get;
            set;
        }

        protected override void Init()
        {
            base.Init();

            namePort = GetInputPort(nameof(paramName));
        }

        protected override void OnTweenStart()
        {
            base.OnTweenStart();

            Name = NamePort.GetInputValue(paramName);

            Id = Shader.PropertyToID(Name);
        }

    }
}
