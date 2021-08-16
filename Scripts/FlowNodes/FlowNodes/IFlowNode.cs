namespace XMonoNode
{
    public interface IFlowNode
    {
        void Flow(NodePort flowPort);
        void Stop();
        void TriggerFlow();
    }
}