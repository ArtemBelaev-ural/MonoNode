﻿using UnityEngine;
using UnityEngine.UI;
using XMonoNode;

namespace XMonoNode
{
    [CreateNodeMenu("UI/" + nameof(ReadInputFieldText), "Input", "Field")]
    public class ReadInputFieldText : MonoNode
    {
        [Input] public InputField inputField;
        [Output] public string fieldText;

        public override object GetValue(NodePort port)
        {
            if (inputField != null)
            {
                return inputField.text;
            }

            return string.Empty;
        }
    }
}
