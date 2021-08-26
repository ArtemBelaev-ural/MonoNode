using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    /// <summary>
    /// Определяет зависимость одного параметра от другого и плавность его изменения
    /// </summary>
    [AddComponentMenu("Math/FloatCurve")]
    [CreateNodeMenu("Float/Curve", -169)]
    [NodeWidth(185)]
    public class FloatCurve : MonoNode
    {
        [Inline]
        [Input]
        public float            input = 0.0f;
        [Output]
        public float            output;

        [SerializeField]
        private AnimationCurve  curve = new AnimationCurve();

        private NodePort inputPort;

        protected override void Init()
        {
            base.Init();
            inputPort = GetInputPort(nameof(input));
        }

        public override object GetValue(NodePort port)
        {
            input = inputPort.GetInputValue(input);
            output = curve.Evaluate(input);
            return output;
        }
    }
}
