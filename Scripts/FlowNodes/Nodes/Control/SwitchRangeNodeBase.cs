using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [System.Serializable]
    public struct Range<T> where T : System.IComparable
    {
        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        public T min;
        public T max;

        public bool check(T value)
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }
    }

    public abstract class SwitchRangeNodeBase<T> : FlowNodeInOut where T : System.IComparable
    {
        [Input(backingValue: ShowBackingValue.Never,
            connectionType: ConnectionType.Multiple,
            typeConstraint: TypeConstraint.None), NodeInspectorButton, Hiding]
        public Flow         reset;

        [Input(connectionType: ConnectionType.Override)]
        public T            value = default(T);

        [Output(dynamicPortList: true, backingValue: ShowBackingValue.Always), NodeInspectorButton, FlowPort]
        public Range<T>[]   Ranges = new Range<T>[0];

        [Input(connectionType: ConnectionType.Override), Hiding]
        public bool         continuous = false; // сигнал, всякий раз, когда значение в диапазоне, иначе только при входе

        private NodePort    resetPort = null;
        private NodePort    valuePort = null;
        private NodePort    continuousPort = null;
        private int         currRangeIndex = -2; // -2 запуск впервые, -1 значение не входит ни в какой диапазон

        protected override void Init()
        {
            base.Init();

            FlowInputPort.label = "Switch";
            FlowOutputPort.label = "Default";
            resetPort = GetInputPort(nameof(reset));
            valuePort = GetInputPort(nameof(value));
            continuousPort = GetInputPort(nameof(continuous));
        }

        public override void Flow(NodePort flowPort)
        {
            if (flowPort == resetPort)
            {
                currRangeIndex = -2; // именно -2, чтобы можно было впервые выбрать значение по умолчанию
            }
            else // Flow
            {
                if (Ranges.Length <= 0)
                {
                    FlowUtils.FlowOutput(FlowOutputPort);
                    return;
                }

                T value = valuePort.GetInputValue(this.value);
                bool caseDefault = true;
                bool continuous = continuousPort.GetInputValue(this.continuous);
                if (value != null)
                {
                    for (int i = 0; i < Ranges.Length; i++)
                    {
                        Range<T> range = Ranges[i];
                        if (range.check(value))
                        {
                            caseDefault = false;
                            if (continuous || i != currRangeIndex)
                            {
                                currRangeIndex = i; // запоминаем текущий диапазон
                                FlowUtils.FlowOutput(GetOutputPort($"{nameof(Ranges)} {i}"));
                            }
                            return; // unable multiple choices!
                        }
                    }
                }

                if (caseDefault && (currRangeIndex != -1 || continuous))
                {
                    currRangeIndex = -1;
                    FlowOut();
                }
            }
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
