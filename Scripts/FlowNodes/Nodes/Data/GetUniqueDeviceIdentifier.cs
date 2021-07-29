using UnityEngine;
using XNode;

namespace FlowNodes
{
    [CreateNodeMenu("Utils/"+nameof(GetUniqueDeviceIdentifier))]
    public class GetUniqueDeviceIdentifier : MonoNode
    {
        [Output] public string deviceId;

        public override object GetValue(NodePort port)
        {
            return port.fieldName == nameof(deviceId) ? SystemInfo.deviceUniqueIdentifier : null;
        }
    }
}