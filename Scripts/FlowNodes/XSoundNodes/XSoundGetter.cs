using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMonoNode
{
    [System.Serializable]
    public class XSoundGetter : FlowNodeGraphGetter, ISerializationCallbackReceiver
    {
        public XSoundGetter(string pathToContainers = "Sounds/XContainers", string containerFileName = "", string graphId = "") :
            base(pathToContainers, containerFileName, graphId)
        {
            drawPathToContainers = false;
        }

        public void OnAfterDeserialize()
        {
            drawPathToContainers = false;
        }

        public void OnBeforeSerialize()
        {
           // throw new System.NotImplementedException();
        }
    }
}
