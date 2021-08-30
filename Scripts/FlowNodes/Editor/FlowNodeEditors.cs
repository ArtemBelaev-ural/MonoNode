using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNode;
using XMonoNodeEditor;

namespace FlowNodesEditor
{
    [CustomNodeEditor(typeof(InputFlowParameterFloat))]
    public class XFlowNodeFloatParameterEditor : NodeEditor
    {
        private InputFlowParameterFloat node = null;
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            if (node == null)
            {
                node = target as InputFlowParameterFloat;
                if (node == null)
                {
                    return;
                }
            }
            serializedObject.Update();

            GUILayout.BeginHorizontal();

            float newValue = GUILayout.HorizontalSlider(node.DefaultValue, 0.0f, 1.0f, GUILayout.MinHeight(10));
            UpdateValue(newValue);

            GUILayout.EndHorizontal();
        }

        private void UpdateValue(float newValue)
        {
            if (!Mathf.Approximately(newValue, node.DefaultValue))
            {
                Undo.RecordObject(node, node.Name);
                node.DefaultValue = newValue;
                FlowNodeGraph flowGraph = node.graph as FlowNodeGraph;
                if (flowGraph != null)
                {
                    flowGraph.UpdateTestParameters();
                }
                EditorUtility.SetDirty(node.gameObject);
            }
        }
    }

    [CustomNodeEditor(typeof(ButtonNode))]
    public class ButtonNodeEditor : NodeEditor
    {
        public ButtonNode Node => target as ButtonNode;

        public override void OnBodyGUI()
        {
            Node.FlowOutputPort.label = Node.ButtonText;
            base.OnBodyGUI();
        }
    }

    [CustomNodeEditor(typeof(FloatEase))]
    public class FloatEaseEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            FloatEase node = target as FloatEase;

            Texture2D tex = node.Clamped01 ? FlowNodeEditorResources.EaseTextureClamped01(node.EasingMode) : FlowNodeEditorResources.EaseTexture(node.EasingMode);
             
            GUILayout.BeginHorizontal();
            GUILayout.Label("", GUILayout.ExpandWidth(true), GUILayout.MinWidth(50));
            GUILayout.Label(new GUIContent(tex), GUILayout.MinWidth(tex.width + 2), GUILayout.Height(tex.height + 2));
            GUILayout.EndHorizontal();
        }
    }
   
    public class AnimateEaseEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            AnimateValue node = target as AnimateValue;

            node.EasingMode = (EasingMode)EditorGUILayout.EnumPopup(new GUIContent(ObjectNames.NicifyVariableName(nameof(AnimateValue.EasingMode))), node.EasingMode);

            Texture2D tex = FlowNodeEditorResources.EaseTextureClamped01(node.EasingMode);

            GUILayout.BeginHorizontal();
            GUILayout.Label("", GUILayout.ExpandWidth(true), GUILayout.MinWidth(50));
            GUILayout.Label(new GUIContent(tex), GUILayout.MinWidth(tex.width + 2), GUILayout.Height(tex.height + 2));
            GUILayout.EndHorizontal();
        }
    }

    [CustomNodeEditor(typeof(AnimateFloatEase))]
    public class AnimateFloatEaseEditor : AnimateEaseEditor
    {
    }

    [CustomNodeEditor(typeof(AnimateVector3Ease))]
    public class AnimateVector3EaseEditor : AnimateEaseEditor
    {
    }

    [CustomNodeEditor(typeof(AnimateColorEase))]
    public class AnimateColorEaseEditor : AnimateEaseEditor
    {
    }


}
