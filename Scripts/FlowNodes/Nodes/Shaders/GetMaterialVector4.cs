using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("Shaders/GetMaterialVector", 427)]
    [NodeWidth(190)]
    public class GetMaterialVector : GetMaterialNamedParameter<Vector4>
    {
        protected override Vector4 GetValue(Material obj)
        {
            return obj.GetVector(NamePort.GetInputValue(paramName));
        }
    }
}
