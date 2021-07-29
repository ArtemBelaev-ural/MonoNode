using UnityEngine;
using XMonoNode;

namespace XMonoNode
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