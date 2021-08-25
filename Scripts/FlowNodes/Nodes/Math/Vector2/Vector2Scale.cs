using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Vector2/Scale", 5)]
    [NodeWidth(150)]
    public class Vector2Scale : MonoNode
    {
        [Input] public Vector2  vector2;
        [Input] public float    scale;

        [Output] public Vector2 scaled;

        private NodePort vector2Port;
        private NodePort scalePort;

        protected override void Init()
        {
            base.Init();

            vector2Port = GetInputPort(nameof(vector2));
            scalePort = GetInputPort(nameof(scale));
        }

        public override object GetValue(NodePort port)
        {
            return vector2Port.GetInputValue(vector2) * scalePort.GetInputValue(scale);
        }
    }
}
