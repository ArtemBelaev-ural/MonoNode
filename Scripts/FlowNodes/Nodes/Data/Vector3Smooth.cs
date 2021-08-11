using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// ќбеспечивает плавное изменение параметра
    /// </summary>
    [CreateNodeMenu("Vector3/Smooth", 31)]
    [NodeWidth(170)]
    [ExecuteInEditMode]
    public class Vector3Smooth : FlowNode
    {

        [Input(connectionType: ConnectionType.Override)]
        public Vector3          Default = Vector3.zero;

        [Input(connectionType: ConnectionType.Override)]
        public Vector3          input;
        [Output]
        public Vector3          smooth;
        

        [Input(connectionType: ConnectionType.Override)]
        public float            lerpCoef = 5.0f;
        

        private void Reset()
        {
            Name = "VectorSmooth (game only)";
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
            smooth = Default;
        }

        private void Update()
        {
            Default = GetInputValue(nameof(Default), Default);
            input = GetInputValue(nameof(input), input);
            lerpCoef = GetInputValue(nameof(lerpCoef), lerpCoef);

            if (!Mathf.Approximately(Vector3.Distance(smooth, input), 0))
            {
                smooth = Vector3.Lerp(smooth, input, Time.deltaTime * lerpCoef);
            }
        }

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(smooth))
            {
                return smooth;
            }
            else
                return null;
        }
    }
}
