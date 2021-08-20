#if DOTWEEN_SUPPORTED
using DG.Tweening;
using XMonoNode;

namespace XMonoNode
{
    public abstract class BaseDoTween : FlowNodeInOut
    {
        [Input(connectionType: ConnectionType.Override)]
        public float Duration = 1;

        [Input(connectionType: ConnectionType.Override)]
        public float DelaySeconds = 0;

        [Input(connectionType: ConnectionType.Override)]
        public int LoopsAmount;


        [NodeEnum]
        public LoopType Loop;

        [NodeEnum]
        public Ease Easing = Ease.Linear;

        protected Tweener tween;

        public override void TriggerFlow()
        {
            //base.TriggerFlow();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }

        protected Tweener SetupTween(Tweener toSetup)
        {
            toSetup.SetDelay(DelaySeconds)
                .SetEase(Easing)
                .SetLoops(LoopsAmount, Loop);
            toSetup.onComplete += OnTweenComplete;
            return toSetup;
        }

        protected void OnTweenComplete()
        {
            base.TriggerFlow();
            tween = null;
        }
    }
}
#endif
