using UnityEngine;

namespace XMonoNode
{
    [ExecuteInEditMode]
    [NodeWidth(150)]
    [CreateNodeMenu("Events/OnFlow", 0)]
    [AddComponentMenu("Mono Node/OnFlow", 0)]
    [NodeTint(40, 60, 105)]
    public class OnFlowEventNode : EventNode
    {
        public override void OnEnable()
        {
            base.OnEnable();
            // Для удобства изменим подпись к стандартным flow портам

            NodePort portIn = GetOutputPort(nameof(FlowOutput));
            if (portIn != null)
            {
                portIn.label = "OnFlow";
            }
        }

        private void Reset()
        {
            Name = "OnFlow";
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
