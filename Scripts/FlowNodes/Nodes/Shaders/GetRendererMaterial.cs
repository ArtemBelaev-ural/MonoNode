using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XMonoNode
{
    [CreateNodeMenu("Shaders/GetRendererMaterial", 470)]
    [NodeWidth(190)]
    public class GetRendererMaterial : GetObjectParameter<Renderer, Material>
    {
        protected override Material GetValue(Renderer obj)
        {
#if UNITY_EDITOR
            return Application.isPlaying ? obj.material : obj.sharedMaterial;
#else
            return obj.material;
#endif
        }
    }
}
