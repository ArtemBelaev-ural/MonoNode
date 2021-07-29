using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XNodeEditor;
using FlowNodes;
using FlowNodesEditor;

namespace BoGD
{
    /// <summary>
    /// Окно звукового графа
    /// </summary>
    [CustomNodeGraphEditor(typeof(XSoundNodeGraph))]
    public class XSoundNodeGraphEditor : NodeGraphEditor
    {
        public override void OnOpen()
        {
            base.OnOpen();
            window.titleContent = new GUIContent("Graph: " + (target as XSoundNodeGraph).gameObject.name);
        }

        public override string GetPortTooltip(XNode.NodePort port)
        {
            // Убираем вытягивание звуков при формировании подсказки, чтобы звуки не появлялись в сцене
            Type portType = port.ValueType;
            if (portType == typeof(List<AudioSource>) ||
                portType == typeof(AudioSources))
            {
                return portType.Name;
            }
            else
            {
                return base.GetPortTooltip(port);
            }
        }

        [MenuItem("GameObject/X Sound Node/Graph", false, 1)]
        public static void CreateXSoundNodeGraph()
        {
            GameObject current = Selection.activeGameObject;
            if (current != null)
            {
                var graph = current.AddComponent<XSoundNodeGraph>();
                NodeEditorWindow.Open(graph);
            }
        }

    }

    /// <summary>
    /// Инспектор звукового графа. Добавляет кнопки play, stop и т.д..
    /// </summary>
    [CustomEditor(typeof(XSoundNodeGraph), true)]
    public class XSoundNodeGraphInspector : FlowNodeGraphInspector
    {
        private XSoundNodeGraph soundNodeGraph = null;

        public override void OnInspectorGUI()
        {
            if (soundNodeGraph == null)
            {
                soundNodeGraph = target as XSoundNodeGraph;
            }

            base.OnInspectorGUI();

            

            // TODO
        }


        protected override string[] GetFlowNodeNames(out int current)
        {
            current = 0;
            if (soundNodeGraph == null)
            {
                return new string[] { FlowNodeGraph.ALL_NODES };
            }
            XSoundNodePlay[] nodes = soundNodeGraph.GetComponents<XSoundNodePlay>();
            string[] result = new string[nodes.Length + 1];
            result[0] = FlowNodeGraph.ALL_NODES;
            for (int i = 0; i < nodes.Length; ++i)
            {
                result[i+1] = nodes[i].Name;
                if (string.IsNullOrWhiteSpace(soundNodeGraph.NodeToTestExecute) == false &&
                    soundNodeGraph.NodeToTestExecute.Equals(nodes[i].Name, StringComparison.OrdinalIgnoreCase))
                {
                    current = i+1;
                }
            }
            return result;
        }
    }
}
