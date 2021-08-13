using UnityEngine;

namespace XMonoNode
{
    [CreateNodeMenu("Events/Lifecicle/" + nameof(OnUpdate), 15)]
    [ExecuteInEditMode]
    [NodeWidth(150)]
    public class OnUpdate : EventNode
    {
        [Input]
        public int Milliseconds;
        private float _timestamp
        {
            get; set;
        }

        private void Update()
        {
            if (Time.realtimeSinceStartup > _timestamp)
            {
                TriggerFlow();
                Milliseconds = GetInputValue(nameof(Milliseconds), Milliseconds);
                _timestamp = Time.realtimeSinceStartup + Milliseconds * 0.001f;
            }
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
