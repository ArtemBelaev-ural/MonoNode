using System;
using UnityEngine;

namespace XMonoNode
{
    public enum NodeInspectorButtonShow
    {
        Settings = 0,
        Always = 1,
        Never = 2,
    }

    /// <summary> Makes a serializable field hidden in node in node graph, but shown in ordinary unity inspector </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class NodeInspectorButtonAttribute : Attribute
    {
        private GUILayoutOption[] options;

        public GUILayoutOption[] Options
        {
            get => options;
            set => options = value;
        }
        
        public NodeInspectorButtonShow ShowButton => showButton;

        private NodeInspectorButtonShow showButton = NodeInspectorButtonShow.Settings;

        public NodeInspectorButtonAttribute(NodeInspectorButtonShow showButton = NodeInspectorButtonShow.Settings)
        {
            this.showButton = showButton;
            this.options = new GUILayoutOption[0];
        }

        public NodeInspectorButtonAttribute(NodeInspectorButtonShow showButton, params GUILayoutOption[] options)
        {
            this.showButton = showButton;
            this.options = options;
        }

        public NodeInspectorButtonAttribute(params GUILayoutOption[] options)
        {
            this.options = options;
        }
    }

}