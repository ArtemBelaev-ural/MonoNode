using UnityEngine;

namespace XMonoNode
{
    [ExecuteInEditMode]
    [NodeWidth(150)]
    [CreateNodeMenu("Events/OnFlowStart", 0)]
    [AddComponentMenu("Mono Node/OnFlow", 0)]
    [NodeTint(40, 60, 105)]
    public class OnFlowEventNode : EventNode
    {
        public override void OnNodeEnable()
        {
            base.OnNodeEnable();
            // Для удобства изменим подпись к стандартным flow портам

            NodePort portIn = GetOutputPort(nameof(FlowOutput));
            if (portIn != null)
            {
                portIn.label = "On Flow Start";
            }
        }

        private void Reset()
        {
            Name = "OnFlowStart";
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
