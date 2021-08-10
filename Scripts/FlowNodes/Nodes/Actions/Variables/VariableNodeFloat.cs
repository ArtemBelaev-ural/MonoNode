using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XMonoNode
{
    [AddComponentMenu("FlowNode/Variables/float", 4)]
    [CreateNodeMenu("Variables/float", 4)]
    public class VariableNodeFloat : VariableNode<float>
    {
        private void Reset()
        {
            Name = "Variable: float"; // в оригинале получается single
        }
    }
}



