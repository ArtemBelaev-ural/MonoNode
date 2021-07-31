using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNode;
using XMonoNodeEditor;

namespace FlowNodesEditor
{
    [CustomNodeEditor(typeof(ExecuteParameterFloat))]
    public class XSoundNodeFloatParameterEditor : NodeEditor
    {
        private ExecuteParameterFloat node = null;
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            if (node == null)
            {
                node = target as ExecuteParameterFloat;
                if (node == null)
                {
                    return;
                }
            }
            serializedObject.Update();
            
            GUILayout.BeginHorizontal();

            GUILayout.Label(new GUIContent("Test:", "Test float parameter of Play()"), GUILayout.MaxWidth(40));
            float newValue = GUILayout.HorizontalSlider(node.TestValue, 0.0f, 1.0f);
            UpdateValue(newValue);
            newValue = EditorGUILayout.FloatField(node.TestValue, GUILayout.MaxWidth(50));
            UpdateValue(newValue);

            GUILayout.EndHorizontal();
        }

        private void UpdateValue(float newValue)
        {
            if (!Mathf.Approximately(newValue, node.TestValue))
            {
                Undo.RecordObject(node, node.Name);
                node.TestValue = newValue;
                FlowNodeGraph flowGraph = node.graph as FlowNodeGraph;
                if (flowGraph != null)
                {
                    flowGraph.UpdateTestParameters();
                }
                EditorUtility.SetDirty(node.gameObject);
            }
        }
    }

    [CustomNodeEditor(typeof(ExecuteParameterVector3))]
    public class ExecuteParameterVector3Editor : NodeEditor
    {
        private ExecuteParameterVector3 node = null;
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            if (node == null)
            {
                node = target as ExecuteParameterVector3;
                if (node == null)
                {
                    return;
                }
            }
            serializedObject.Update();
            EditorGUILayout.BeginHorizontal();
            Vector3 oldValue = node.TestValue;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("testValue"), new GUIContent());

            if (!Mathf.Approximately((oldValue - node.TestValue).magnitude, 0.0f))
            {
                FlowNodeGraph flowGraph = node.graph as FlowNodeGraph;
                if (flowGraph != null)
                {
                    flowGraph.UpdateTestParameters();
                }
            }

            EditorGUILayout.EndHorizontal();
        }
    }

    public class XSoundNodeParameterEditor<N, T> : NodeEditor where N : ExecuteParameter<T> 
    {
        private N node = null;
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            if (node == null)
            {
                node = target as N;
                if (node == null)
                {
                    return;
                }
            }
            serializedObject.Update();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(new GUIContent("Test:", "Test parameter of Play()"), GUILayout.MaxWidth(40));

            T oldValue = node.TestValue;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("testValue"), new GUIContent());
            if (node.TestValue != null && !node.TestValue.Equals(oldValue))
            {
                FlowNodeGraph flowGraph = node.graph as FlowNodeGraph;
                if (flowGraph != null)
                {
                    flowGraph.UpdateTestParameters();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    [CustomNodeEditor(typeof(ExecuteParameterGameObject))]
    public class ExecuteParameterGameObjectEditor : XSoundNodeParameterEditor<ExecuteParameterGameObject, GameObject> 
    { 
    }

    [CustomNodeEditor(typeof(ExecuteParameterTransform))]
    public class ExecuteParameterTransformEditor : XSoundNodeParameterEditor<ExecuteParameterTransform, Transform>
    { 
    }

    [CustomNodeEditor(typeof(XSoundNodeIntParameter))]
    public class ExecuteParameterIntEditor : XSoundNodeParameterEditor<XSoundNodeIntParameter, int>
    { 
    }

    [CustomNodeEditor(typeof(ExecuteParameterString))]
    public class ExecuteParameterStringEditor : XSoundNodeParameterEditor<ExecuteParameterString, string>
    {
    }

}
