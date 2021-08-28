using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("Shaders/GetMaterialInt", 421)]
    [NodeWidth(190)]
    public class GetMaterialInt : GetMaterialNamedParameter<int>
    {
        protected override int GetValue(Material obj)
        {
            return obj.GetInt(NamePort.GetInputValue(paramName));
        }
    }
}
