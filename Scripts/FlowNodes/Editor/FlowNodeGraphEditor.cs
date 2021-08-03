using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNode;
using XMonoNodeEditor;

namespace FlowNodesEditor
{
    /// <summary>
    /// Окно графа
    /// </summary>
    [CustomNodeGraphEditor(typeof(FlowNodeGraph))]
    public class FlowNodeGraphGraphEditor : NodeGraphEditor
    {
        public override void OnOpen()
        {
            base.OnOpen();
            window.titleContent = new GUIContent("Graph: " + (target as FlowNodeGraph).gameObject.name);
        }

        [MenuItem("GameObject/FlowNodes/Graph", false, 1)]
        public static void CreateFlowNodeGraph()
        {
            GameObject current = Selection.activeGameObject;
            if (current != null)
            {
                var graph = current.AddComponent<FlowNodeGraph>();
                NodeEditorWindow.Open(graph);
            }
        }

    }

    /// <summary>
    /// Инспектор графа. Добавляет кнопки execute, stop и т.д..
    /// </summary>
    [CustomEditor(typeof(FlowNodeGraph), true)]
    public class FlowNodeGraphInspector : MonoNodeInspector
    {
        private FlowNodeGraph flowNodeGraph = null;

        public override void OnInspectorGUI()
        {
            if (flowNodeGraph == null)
            {
                flowNodeGraph = target as FlowNodeGraph;
            }
            base.OnInspectorGUI();

            if (flowNodeGraph == null)
            {
                GUILayout.Label(new GUIContent("flowNodeGraph is null".Color(Color.red)));
                return;
            }

            GUILayout.Label(new GUIContent("<color=green>=== Test ===</color>", "test float parameter of Execute()"), GUIStyle.none);

            // Start/Stop buttons

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Execute", GUILayout.Height(40)))
            {
                if (Application.isPlaying == false)
                {
                    OpenGraph();
                }
                flowNodeGraph.TestExecute();
            }
            if (GUILayout.Button("Stop", GUILayout.Height(40)))
            {
                flowNodeGraph.Stop();
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);
        }
    }
}
