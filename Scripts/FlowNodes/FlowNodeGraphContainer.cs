using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XMonoNode
{
    [System.Serializable]
    public class FlowNodeGraphContainerItem
    {
        [SerializeField]
        [Header("id - для кода")]
        private string          id = "";

        [SerializeField]
        [Header("Префаб графа")]
        private FlowNodeGraph   graph = null;

        public string           Id => id;

        public Object           Prefab => graph;

        private FlowNodeGraph   instanciated = null;

        public FlowNodeGraph Get()
        {
            if (graph == null)
            {
                Debug.LogErrorFormat("Graph Events Kit (FlowNodeGraphContainer): graph not set to Id: \"{0}\"", id);
                return null;
            }

            if (instanciated == null)
            {
                instanciated = GameObject.Instantiate(graph);
#if UNITY_EDITOR
                instanciated.gameObject.hideFlags = HideFlags.HideAndDontSave;
#endif
                instanciated.name = $"(FlowNodeGraphContainer id=\"{id}\")";
                instanciated.transform.localPosition = Vector3.zero;
            }
            return instanciated;
        }
    }


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


        public void UpdateParameters(string id, params object[] parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.UpdateParameters(parameters);
            }
        }

        public void UpdateParameters(string id, Dictionary<string, object> parameters)
        {
            FlowNodeGraph graph = Get(id);
            if (graph != null)
            {
                graph.UpdateParameters(parameters);
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
