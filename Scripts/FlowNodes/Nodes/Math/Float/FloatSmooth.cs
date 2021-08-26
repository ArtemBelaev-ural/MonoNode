using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ќбеспечивает плавное изменение параметра
    /// </summary>
    [CreateNodeMenu("Float/Smooth", -163)]
    [NodeWidth(170)]
    [ExecuteInEditMode]
    public class FloatSmooth : FlowNodeInOut
    {

        [Input(connectionType: ConnectionType.Override)]
        public float            Default = 0.0f;

        [Inline]
        [Input(connectionType: ConnectionType.Override)]
        public float            input = 0.0f;
        [Output]
        public float            lerpOutput = 0.0f;
        

        [Input(connectionType: ConnectionType.Override)]
        public float            lerpUp = 10000.0f;
        [Input(connectionType: ConnectionType.Override)]
        public float            lerpDown = 5.0f;
        
        private NodePort DefaultPort;
        private NodePort inputPort;
        private NodePort lerpUpPort;
        private NodePort lerpDownPort;

        private void Reset()
        {
            Name = "FloatSmooth (game only)";
        }

        protected override void Init()
        {
            base.Init();
            DefaultPort = GetInputPort(nameof(Default));
            inputPort = GetInputPort(nameof(input));
            lerpUpPort = GetInputPort(nameof(lerpUp));
            lerpDownPort = GetInputPort(nameof(lerpDown));
        }

        public override void OnNodeEnable()
        {
            base.OnNodeEnable();
            NodePort flowInputPort = GetInputPort(nameof(FlowInput));
            if (flowInputPort != null)
            {
                flowInputPort.label = "Set Default";
            }
        }

        public override void Flow(NodePort flowPort)
        {
            lerpOutput = Default;
        }

        private void Update()
        {
            Default = DefaultPort.GetInputValue(Default);
            input = inputPort.GetInputValue(input);
            lerpUp = lerpUpPort.GetInputValue(lerpUp);
            lerpDown = lerpDownPort.GetInputValue(lerpDown);

            if (!Mathf.Approximately(lerpOutput, input))
            {
                lerpOutput = Mathf.Lerp(lerpOutput, input, Time.deltaTime * (input > lerpOutput ? lerpUp : lerpDown));
            }
        }

        public override object GetValue(NodePort port)
        {
            return lerpOutput;
        }
    }
}
