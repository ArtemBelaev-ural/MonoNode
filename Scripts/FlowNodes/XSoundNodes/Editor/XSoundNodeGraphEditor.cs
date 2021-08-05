using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNodeEditor;
using FlowNodesEditor;

namespace XMonoNode
{
    /// <summary>
    /// ���� ��������� �����
    /// </summary>
    [CustomNodeGraphEditor(typeof(XSoundNodeGraph))]
    public class XSoundNodeGraphEditor : FlowNodeGraphGraphEditor
    {
        public override string GetPortTooltip(XMonoNode.NodePort port)
        {
            // ������� ����������� ������ ��� ������������ ���������, ����� ����� �� ���������� � �����
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
    /// ��������� ��������� �����. ��������� ������ play, stop � �.�..
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

            

            // TODO playing information
        }

    }
}
