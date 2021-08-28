using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("Shaders/SetMaterialInt", 421)]
    [NodeWidth(190)]
    public class SetMaterialInt : SetMaterialNamedParameter<int>
    {
        protected override void SetValue(Material obj, int value)
        {
            obj.SetInt(NamePort.GetInputValue(paramName), value);
        }
    }
}
