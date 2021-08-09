using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNodeEditor;

namespace XMonoNode
{
    [CustomNodeEditor(typeof(XSoundNodePlay))]
    public class XSoundNodePlayEditor : NodeEditor
    {
        private XSoundNodePlay node = null;

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            if (node == null)
            {
                node = target as XSoundNodePlay;
            }

            serializedObject.Update();

            EditorGUILayout.BeginHorizontal();
            if (EditorGUILayout.LinkButton("[play]"))
            {
                node.TestPlay();
            }
            if (EditorGUILayout.LinkButton("[stop]"))
            {
                node.Stop();
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    [CustomPropertyDrawer(typeof(XSoundSelectorAttribute))]
    public class XSoundSelectorDrawer: PropertyDrawer
    {
        private string[]  values = null;

        protected List<int> identificators = null;

        protected void AddItem(int id, string value)
        {
            values[identificators.Count] = value;
            identificators.Add(id);
        }

        private void Init(Dictionary<int, string> soundsDict)
        {
            values = new string[soundsDict.Count + 1];
            identificators = new List<int>(values.Length);

            AddItem(-1, "-: None");

            foreach (var pair in soundsDict)
            {
               AddItem(pair.Key, pair.Value + ": " + pair.Key);
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null)
            {
                return;
            }
            
            Init(IXSoundsLibraryInstance.Get().GetSounds());

            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Calculate rects
            Rect pathRect = new Rect(position.x + 0 * position.width / 2 + 0 * 4, position.y, position.width - 6, position.height);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int intValue = property.intValue;
            

            if (NodeEditorWindow.current != null &&
                NodeEditorWindow.current.zoom >= 0.9f && NodeEditorWindow.current.zoom <= 1.3f)
            {
                int popupValue = EditorGUI.Popup(pathRect, Mathf.Max(0, identificators.IndexOf(intValue)), values);
                intValue = identificators[popupValue];
                property.intValue = intValue;
            }
            else
            {
                GUI.Label(pathRect, new GUIContent(values[Mathf.Max(0, identificators.IndexOf(intValue))]));
            }
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
