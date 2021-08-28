using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("Shaders/GetRendererMaterial", 418)]
    [NodeWidth(190)]
    public class GetRendererMaterial : GetObjectParameter<Renderer, Material>
    {
        protected override Material GetValue(Renderer obj)
        {
            return obj.material;
        }
    }
}
