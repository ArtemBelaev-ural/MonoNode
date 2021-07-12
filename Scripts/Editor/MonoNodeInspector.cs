using UnityEditor;
using UnityEngine;
using System;
using XNode;

namespace XNodeEditor {
    [UnityEditor.CustomEditor(typeof(MonoNodeGraph), true)]
    public class MonoNodeInspector : Editor
    {
        private MonoNodeGraph graph;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(GUILayout.Button("Open graph", GUILayout.Height(50)))
            {
                NodeEditorWindow.Open(target as INodeGraph);
            }
        }
       
    }
}
