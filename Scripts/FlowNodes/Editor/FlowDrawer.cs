using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XMonoNode;

namespace XMonoNodeEditor
{
    //[CustomPropertyDrawer(typeof(Flow), true)]
    public class FlowDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            
            base.OnGUI(position, property, label);

            if (property == null)
            {
                return;
            }
            
            XMonoNode.INode node = property.serializedObject.targetObject as XMonoNode.INode;

            if (node == null)
            {
                return;
            }
            XMonoNode.NodePort port = node.GetPort(property.name);
            if (port == null)
            {
                return;
            }

           // Debug.Log(port.label + " " + NodeEditorUtilities.PortButtonPressedCount());

            if (port.direction == NodePort.IO.Output && NodeEditorUtilities.GetPortButtonPressed(port))
            {
                Debug.Log(port.label);
                FlowUtils.TriggerFlow(port);
            }
        }

      
    }

}
