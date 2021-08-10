using System;
using System.Collections.Generic;
using UnityEngine;

namespace XMonoNode
{
    [System.Serializable]
    public class FlowNodeGraphGetter
    {
        public static string NO_CONTAINER = "-: None";

        // Common usage: link to FlowNodeGraph container item by graphId
        [SerializeField]
        private string          pathToContainers = "";
        [SerializeField]
        private string          containerFileName = "";
        [SerializeField]
        private string          graphId = "";

        [SerializeField]
        protected bool          drawPathToContainers = true;

        // alternative usage - link to prefab directly
        [SerializeField]
        private FlowNodeGraph   graphPrefab = null;

        public bool IsEmpty
        {
            get => (string.IsNullOrEmpty(containerFileName) || containerFileName == NO_CONTAINER) ? graphPrefab == null : (string.IsNullOrEmpty(graphId) || string.IsNullOrEmpty(FullPath));
        }

        public string PathToContainers
        {
            get => pathToContainers;
            set
            {
                pathToContainers = value;
            }
        }

        private string FullPath => pathToContainers + containerFileName;

        public FlowNodeGraphGetter()
        {
        }

        public FlowNodeGraphGetter(string pathToContainers, string containerFileName = "", string graphId = "")
        {
            this.pathToContainers = pathToContainers;
            this.containerFileName = containerFileName;
            this.graphId = graphId;
        }

        public FlowNodeGraphGetter(FlowNodeGraph graphPrefab)
        {
            this.graphPrefab = graphPrefab;
        }

        private FlowNodeGraphContainer instanciatedContainer = null;

        private FlowNodeGraphContainer GetContainer()
        {
            if (instanciatedContainer == null)
            {
                var res = ResourcesLoader.Load<FlowNodeGraphContainer>(FullPath);
                if (res != null)
                {
                    if (Application.isPlaying)
                    {
                        instanciatedContainer = GameObject.Instantiate(res);
#if UNITY_EDITOR
                        if (Application.isEditor)
                        {
                            instanciatedContainer.gameObject.hideFlags = HideFlags.HideAndDontSave;
                        }
#endif
                    }
                    else
                    {
                        instanciatedContainer = res;
                    }
                }
            }
            return instanciatedContainer;
        }

        public FlowNodeGraph Flow(params object[] parameters)
        {
            if (GetContainer() == null)
            {
                Debug.LogErrorFormat("Container is null, {0}", FullPath);
                return null;
            }

            return GetContainer().Flow(graphId, parameters);
        }

        public FlowNodeGraph Flow(Dictionary<string, object> parameters)
        {
            if (GetContainer() == null)
            {
                Debug.LogErrorFormat("Container is null, {0}", FullPath);
                return null;
            }

            return GetContainer().Flow(graphId, parameters);
        }

        public FlowNodeGraph Get()
        {
            if (GetContainer() == null)
            {
                Debug.LogErrorFormat("Container is null, {0}", FullPath);
                return null;
            }

            return GetContainer().Get(graphId);
        }

        public void UpdateParameters(params object[] parameters)
        {
            if (GetContainer() == null)
            {
                Debug.LogErrorFormat("Container is null, {0}", FullPath);
                return;
            }
            GetContainer().UpdateParameters(graphId, parameters);
        }

        public void UpdateParameters(Dictionary<string, object> parameters)
        {
            if (GetContainer() == null)
            {
                Debug.LogErrorFormat("Container is null, {0}", FullPath);
                return;
            }
            GetContainer().UpdateParameters(graphId, parameters);
        }

        public void Stop()
        {
            if (GetContainer() == null)
            {
                Debug.LogErrorFormat("Container is null, {0}", FullPath);
                return;
            }

            GetContainer().Stop(graphId);
        }

    }
}