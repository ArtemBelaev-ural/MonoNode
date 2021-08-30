using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XMonoNode
{
    /// <summary>
    /// Instanciates a concrete graph object
    /// </summary>
    [System.Serializable]
    public class FlowNodeGraphContainerItem
    {
        [SerializeField]
        [Header("graph id")]
        private string          id = "";

        [SerializeField]
        [Header("Graph prefab")]
        private FlowNodeGraph   graph = null;

        public string           Id => id;

        public Object           Prefab => graph;

        private FlowNodeGraph   instanciated = null;

        public FlowNodeGraph Get()
        {
            if (graph == null)
            {
                Debug.LogErrorFormat("FlowNodeGraphContainer: graph not set to Id: \"{0}\"", id);
                return null;
            }

            if (instanciated == null)
            {
                instanciated = GameObject.Instantiate(graph);
#if UNITY_EDITOR
                if (Application.isEditor)
                {
                    instanciated.gameObject.hideFlags = HideFlags.HideAndDontSave;
                }
#endif
                instanciated.name = $"(FlowNodeGraphContainer id=\"{id}\")";
                instanciated.transform.localPosition = Vector3.zero;
            }
            return instanciated;
        }
    }

    /// <summary>
    ///Allows you to manage and instanciate flow node graphs
    /// </summary>
    [AddComponentMenu("X Mono Node/FlowNodeGraphContainer", 701)]
    public class FlowNodeGraphContainer : MonoBehaviour
    {
        [SerializeField]
        private List<FlowNodeGraphContainerItem>                itemsList = null;

        public List<FlowNodeGraphContainerItem>                 ItemsList => itemsList;

        private Dictionary<string, FlowNodeGraphContainerItem>  items = null;
        private Dictionary<string, FlowNodeGraphContainerItem>  Items
        {
            get
            {
                if (items == null)
                {
                    items = new Dictionary<string, FlowNodeGraphContainerItem>();
                    foreach (var setting in itemsList)
                    {
                        items[setting.Id] = setting;
                    }
                }
                return items;
            }
        }

        private List<FlowNodeGraph>         instanciated = new List<FlowNodeGraph>();

        public FlowNodeGraph Flow(string id, params object[] parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.Flow(parameters);
            }
            return graph;
        }

        public FlowNodeGraph Flow(string id, System.Action<string> onEndAction, string state, params object[] parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.Flow(onEndAction, state, parameters);
            }
            return graph;
        }

        public FlowNodeGraph Flow(string id, Dictionary<string, object> parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.Flow(parameters);
            }
            return graph;
        }

        public FlowNodeGraph Flow(string id, System.Action<string> onEndAction, string state, Dictionary<string, object> parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.Flow(onEndAction, state, parameters);
            }
            return graph;
        }

        public FlowNodeGraph Get(string id)
        {
            if (Items.TryGetValue(id, out FlowNodeGraphContainerItem item))
            {
                return item.Get();
            }
            else
            {
                Debug.LogErrorFormat("FlowNode Graph Container {0} hasn't Id \"{1}\"", name, id);
                return null;
            }
        }

        public Object GetPrefab(string id)
        {
            if (Items.TryGetValue(id, out FlowNodeGraphContainerItem item))
            {
                return item.Prefab;
            }
            else
            {
                return null;
            }
        }


        public void UpdateInputParameters(string id, params object[] parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.UpdateInputParameters(parameters);
            }
        }

        public void UpdateInputParameters(string id, Dictionary<string, object> parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.UpdateInputParameters(parameters);
            }
        }

        public void GetOutputParameters(string id, out Dictionary<string, object> parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.GetOutputParameters(out parameters);
            }
            else
            {
                parameters = new Dictionary<string, object>();
            }
        }

        public void Stop(string id)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.Stop();
            }
        }

        public void StopAll()
        {
            itemsList.ForEach(item => item.Get()?.Stop());
        }

    }
}
