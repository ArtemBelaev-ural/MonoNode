﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("Float/Max", 72)]
    [NodeWidth(180)]
    public class FloatMax : MonoNode
    {
        [Input(
            backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Override,
            dynamicPortList: true)]

        public List<float> inputs = new List<float>();

        [Output]
        public float max;

        private void Reset()
        {
            inputs.Add(1);
            inputs.Add(2);
            inputs.Add(3);
        }

        public override object GetValue(NodePort port)
        {
            return GetMax();
        }

        private float GetMax()
        {
            if (inputs.Count == 0)
            {
                return 0;
            }

            float max = inputs[0];

            for (int i = 0; i < inputs.Count; ++i)
            {
                NodePort port = GetPort(nameof(inputs) + " " + i);
                if (port != null)
                {
                    inputs[i] = port.GetInputValue(inputs[i]);
                }
                if (inputs[i] > max)
                {
                    max = inputs[i];
                }
            }

            return max;
        }
    }
}