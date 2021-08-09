using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ќбеспечивает плавное изменение параметра
    /// </summary>
    [AddComponentMenu("Math/LerpFloat")]
    [CreateNodeMenu("Math/LerpFloat")]
    [NodeWidth(170)]
    [ExecuteInEditMode]
    public class LerpFloat : FlowNode
    {

        [Input(connectionType: ConnectionType.Override)]
        public float            Default = 0.0f;

        [Input(connectionType: ConnectionType.Override)]
        public float            input = 0.0f;
        [Output]
        public float            lerpOutput = 0.0f;
        

        [Input(connectionType: ConnectionType.Override)]
        public float            lerpUp = 10000.0f;
        [Input(connectionType: ConnectionType.Override)]
        public float            lerpDown = 5.0f;
        

        private void Reset()
        {
            Name = "LerpFloat (game only)";
        }

        public override void OnEnable()
        {
            base.OnEnable();
            NodePort flowInputPort = GetInputPort(nameof(FlowInput));
            if (flowInputPort != null)
            {
                flowInputPort.label = "Set Default";
            }
        }

        public override void Flow()
        {
            lerpOutput = Default;
        }

        private void Update()
        {
            Default = GetInputValue(nameof(Default), Default);
            input = GetInputValue(nameof(input), input);
            lerpUp = GetInputValue(nameof(lerpUp), lerpUp);
            lerpDown = GetInputValue(nameof(lerpDown), lerpDown);

            if (!Mathf.Approximately(lerpOutput, input))
            {
                lerpOutput = Mathf.Lerp(lerpOutput, input, Time.deltaTime * (input > lerpOutput ? lerpUp : lerpDown));
            }
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(lerpOutput))
            {
                return lerpOutput;
            }
            else
                return null;
        }
    }
}
