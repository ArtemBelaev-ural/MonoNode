using System;
using System.Threading.Tasks;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Time/GetDeltaTime", 539)]
    [NodeWidth(150)]
    public class GetDeltaTime : MonoNode
    {
        [Output] public float deltaTime;
        [Output] public float fixedDeltaTime;

        private NodePort deltaTimePort;
        private NodePort fixedDeltaTimePort;

        protected override void Init()
        {
            base.Init();

            deltaTimePort = GetOutputPort(nameof(deltaTime));
            fixedDeltaTimePort = GetOutputPort(nameof(fixedDeltaTime));
        }

        public override object GetValue(NodePort port)
        {
            if (port == deltaTimePort)
            {
                return Time.deltaTime;
            }
            else if (port == fixedDeltaTimePort)
            {
                return Time.fixedDeltaTime;
            }

            return null;
        }

    }
}
