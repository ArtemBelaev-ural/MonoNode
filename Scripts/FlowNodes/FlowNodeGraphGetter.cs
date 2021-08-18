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

        private bool CheckContainer()
        {
            if (GetContainer() != null)
            {
                return true;
            }
            Debug.LogErrorFormat("Container is null, {0}", FullPath);
            return false;
        }

        public void Flow(params object[] parameters)
        {
            if (CheckContainer())
            {
                GetContainer().Flow(graphId, parameters);
            }
        }

        public void Flow(Dictionary<string, object> parameters)
        {
            if (CheckContainer())
            {
                GetContainer().Flow(graphId, parameters);
            }
        }

        public void UpdateInputParameters(params object[] parameters)
        {
            if (CheckContainer())
            {
                GetContainer().UpdateInputParameters(graphId, parameters);
            }
        }

        public void UpdateInputParameters(Dictionary<string, object> parameters)
        {
            if (CheckContainer())
            {
                GetContainer().UpdateInputParameters(graphId, parameters);
            }
        }

        public void GetOutputParameters(out Dictionary<string, object> parameters)
        {
            if (CheckContainer())
            {
                GetContainer().GetOutputParameters(graphId, out parameters);
            }
            else
            {
                parameters = new Dictionary<string, object>();
            }
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