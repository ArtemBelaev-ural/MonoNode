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
    [CreateNodeMenu("Float/Curve", 61)]
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

        public override object GetValue(NodePort port)
        {
            UnityEngine.UIElements.Experimental.Easing.InBack(1);
            if (port.fieldName == nameof(output))
            {
                input = GetInputValue(nameof(input), input);
                output = curve.Evaluate(input);
                return output;
            }
            else return null;
        }
    }
}
