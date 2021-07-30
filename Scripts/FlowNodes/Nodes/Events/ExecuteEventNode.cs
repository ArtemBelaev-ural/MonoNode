using UnityEngine;

namespace XMonoNode
{
    [ExecuteInEditMode]
    [NodeWidth(150)]
    [CreateNodeMenu("Events/Execute Event", 0)]
    [AddComponentMenu("Mono Node/Execute Event", 0)]
    [NodeTint(40, 60, 105)]
    public class ExecuteEventNode : EventNode
    {
        public override void OnEnable()
        {
            base.OnEnable();
            // Для удобства изменим подпись к стандартным flow портам

            NodePort portIn = GetOutputPort(nameof(FlowOutput));
            if (portIn != null)
            {
                portIn.label = "Execute";
            }
        }

        private void Reset()
        {
            Name = "Execute Event";
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
