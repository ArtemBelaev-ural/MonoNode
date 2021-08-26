using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ќбеспечивает плавное изменение параметра
    /// </summary>
    [CreateNodeMenu("Vector4/Smooth", 31)]
    [ExecuteInEditMode]
    public class Vector4Smooth : FlowNodeInOut
    {
        [Input(connectionType: ConnectionType.Override)]
        public Vector4          Default = Vector3.zero;

        [Input(connectionType: ConnectionType.Override)]
        public Vector4          input;

        [Output]
        public Vector4          smooth;
        

        [Input(connectionType: ConnectionType.Override)]
        public float            lerpCoef = 5.0f;

        private NodePort DefaultPort;
        private NodePort inputPort;
        private NodePort smoothPort;
        private NodePort lerpCoefPort;

        private void Reset()
        {
            Name = "VectorSmooth (game only)";
        }

        protected override void Init()
        {
            base.Init();
            NodePort flowInputPort = GetInputPort(nameof(FlowInput));
            if (flowInputPort != null)
            {
                flowInputPort.label = "Set Default";
            }

            DefaultPort  = GetInputPort(nameof(Default));
            inputPort    = GetInputPort(nameof(input));
            smoothPort  = GetOutputPort(nameof(smooth));
            lerpCoefPort = GetInputPort(nameof(lerpCoef));
        }

        public override void Flow(NodePort flowPort)
        {
            smooth = Default;
        }

        private void Update()
        {
            Default = DefaultPort.GetInputValue(Default);
            input = inputPort.GetInputValue(input);
            lerpCoef = lerpCoefPort.GetInputValue(lerpCoef);

            if (!Mathf.Approximately(Vector4.Distance(smooth, input), 0))
            {
                smooth = Vector4.Lerp(smooth, input, Time.deltaTime * lerpCoef);
            }
        }

        public override object GetValue(NodePort port)
        {
            if (port == smoothPort)
            {
                return smooth;
            }
            else
                return null;
        }
    }
}
