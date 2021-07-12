using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

namespace XNodeEditor {
    /// <summary> Deals with modified assets </summary>
    class NodeGraphImporter : AssetPostprocessor {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
            foreach (string path in importedAssets) {
                // Skip processing anything without the .asset extension
                if (Path.GetExtension(path) != ".asset") continue;

                // Get the object that is requested for deletion
                XNode.NodeGraph graph = AssetDatabase.LoadAssetAtPath<XNode.NodeGraph>(path);
                if (graph == null) continue;

                // Get attributes
                Type graphType = graph.GetType();
                XNode.RequireNodeAttribute[] attribs = Array.ConvertAll(
                    graphType.GetCustomAttributes(typeof(XNode.RequireNodeAttribute), true), x => x as XNode.RequireNodeAttribute);

                Vector2 position = Vector2.zero;
                foreach (XNode.RequireNodeAttribute attrib in attribs) {
                    if (attrib.type0 != null) AddRequired(graph, attrib.type0, ref position);
                    if (attrib.type1 != null) AddRequired(graph, attrib.type1, ref position);
                    if (attrib.type2 != null) AddRequired(graph, attrib.type2, ref position);
                }
            }
        }

        private static void AddRequired(XNode.INodeGraph graph, Type type, ref Vector2 position) {
            if (!graph.GetNodes().Any(x => x.GetType() == type)) {
                XNode.INode node = graph.AddNode(type);
                node.Position = position;
                position.x += 200;
                if (node.Name == null || node.Name.Trim() == "") node.Name = NodeEditorUtilities.NodeDefaultName(type);
                if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(graph as UnityEngine.Object))) AssetDatabase.AddObjectToAsset(node as UnityEngine.Object, graph as UnityEngine.Object);
            }
        }
    }
}