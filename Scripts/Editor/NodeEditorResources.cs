using UnityEditor;
using UnityEngine;

namespace XMonoNodeEditor {
    public static class NodeEditorResources {
        // Textures
        public static Texture2D dot { get { return _dot != null ? _dot : _dot = Resources.Load<Texture2D>("xnode_dot"); } }
        private static Texture2D _dot;

        public static Texture2D dotOuter { get { return _dotOuter != null ? _dotOuter : _dotOuter = Resources.Load<Texture2D>("xnode_dot_outer"); } }
        private static Texture2D _dotOuter;

        public static Texture2D flow
        {
            get
            {
                return _flow != null ? _flow : _flow = Resources.Load<Texture2D>("xnode_flow");
            }
        }
        private static Texture2D _flow;

        public static Texture2D flowOuter
        {
            get
            {
                return _flowOuter != null ? _flowOuter : _flowOuter = Resources.Load<Texture2D>("xnode_flow_outer");
            }
        }
        private static Texture2D _flowOuter;

        public static Texture2D nodeBody { get { return _nodeBody != null ? _nodeBody : _nodeBody = Resources.Load<Texture2D>("xnode_node"); } }
        private static Texture2D _nodeBody;

        public static Texture2D nodeBodySmall
        {
            get
            {
                return _nodeBodySmall != null ? _nodeBodySmall : _nodeBodySmall = Resources.Load<Texture2D>("xnode_node_small");
            }
        }
        private static Texture2D _nodeBodySmall;

        public static Texture2D nodeHighlight { get { return _nodeHighlight != null ? _nodeHighlight : _nodeHighlight = Resources.Load<Texture2D>("xnode_node_highlight"); } }
        private static Texture2D _nodeHighlight;

        public static Texture2D graph
        {
            get
            {
                return _graph != null ? _graph : _graph = Resources.Load<Texture2D>("graph");
            }
        }
        static Texture2D _graph = null;

        public static Texture2D IconPlay16
        {
            get
            {
                return iconPlay16 != null ? iconPlay16 : iconPlay16 = Resources.Load<Texture2D>("xnode_icon_play_16");
            }
        }
        private static Texture2D iconPlay16 = null;

        public static Texture2D IconPlay16Hover
        {
            get
            {
                return iconPlay16Hover != null ? iconPlay16Hover : iconPlay16Hover = Resources.Load<Texture2D>("xnode_icon_play_16_hover");
            }
        }
        private static Texture2D iconPlay16Hover = null;

        public static Texture2D IconPlay16Active
        {
            get 
            {
                return iconPlay16Active != null ? iconPlay16Active : iconPlay16Active = Resources.Load<Texture2D>("xnode_icon_play_16_active");
            }
        }
        private static Texture2D iconPlay16Active = null;

        public static Texture2D IconError16
        {
            get
            {
                return iconError16 != null ? iconError16 : iconError16 = Resources.Load<Texture2D>("xnode_icon_error_16");
            }
        }
        private static Texture2D iconError16 = null;

        // Styles
        public static Styles styles { get { return _styles != null ? _styles : _styles = new Styles(); } }
        public static Styles _styles = null;
        public static GUIStyle OutputPort { get { return new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperRight }; } }
        public class Styles
        {
            public GUIStyle inputPort, outputPort, inputPortFlow, outputPortFlow, nodeHeader, nodeBody, tooltip, nodeHighlight, playButton, errorButton;

            public Styles()
            {
                GUIStyle baseStyle = new GUIStyle("Label");
                baseStyle.fixedHeight = 18;

                inputPort = new GUIStyle(baseStyle);
                inputPort.alignment = TextAnchor.UpperLeft;
                inputPort.padding.left = 0;
                inputPort.active.background = dot;
                inputPort.normal.background = dotOuter;

                outputPort = new GUIStyle(baseStyle);
                outputPort.alignment = TextAnchor.UpperRight;
                outputPort.padding.right = 0;
                outputPort.active.background = dot;
                outputPort.normal.background = dotOuter;

                inputPortFlow = new GUIStyle(baseStyle);
                inputPortFlow.alignment = TextAnchor.UpperLeft;
                inputPortFlow.padding.left = 0;
                inputPortFlow.active.background = flow;
                inputPortFlow.normal.background = flowOuter;

                outputPortFlow = new GUIStyle(baseStyle);
                outputPortFlow.alignment = TextAnchor.UpperRight;
                outputPortFlow.padding.right = 0;
                outputPortFlow.active.background = flow;
                outputPortFlow.normal.background = flowOuter;

                nodeHeader = new GUIStyle();
                nodeHeader.alignment = TextAnchor.MiddleCenter;
                nodeHeader.fontStyle = FontStyle.Bold;
                nodeHeader.normal.textColor = Color.white;

                nodeBody = new GUIStyle();
                nodeBody.normal.background = NodeEditorResources.nodeBody;
                nodeBody.border = new RectOffset(32, 32, 32, 32);
                nodeBody.padding = new RectOffset(16, 16, 4, 16);

                nodeHighlight = new GUIStyle();
                nodeHighlight.normal.background = NodeEditorResources.nodeHighlight;
                nodeHighlight.border = new RectOffset(32, 32, 32, 32);

                tooltip = new GUIStyle("helpBox");
                tooltip.alignment = TextAnchor.MiddleCenter;

                playButton = new GUIStyle(baseStyle);
                playButton.alignment = TextAnchor.MiddleCenter;
                playButton.active.background = IconPlay16Active;
                playButton.normal.background = IconPlay16;
                playButton.hover.background = IconPlay16Hover;

                errorButton = new GUIStyle(baseStyle);
                errorButton.alignment = TextAnchor.MiddleCenter;
                errorButton.active.background = IconError16;
                errorButton.normal.background = IconError16;
            }
        }

        public static Texture2D GenerateGridTexture(Color line, Color bg) {
            Texture2D tex = new Texture2D(64, 64);
            Color[] cols = new Color[64 * 64];
            for (int y = 0; y < 64; y++) {
                for (int x = 0; x < 64; x++) {
                    Color col = bg;
                    if (y % 16 == 0 || x % 16 == 0) col = Color.Lerp(line, bg, 0.65f);
                    if (y == 63 || x == 63) col = Color.Lerp(line, bg, 0.35f);
                    cols[(y * 64) + x] = col;
                }
            }
            tex.SetPixels(cols);
            tex.wrapMode = TextureWrapMode.Repeat;
            tex.filterMode = FilterMode.Bilinear;
            tex.name = "Grid";
            tex.Apply();
            return tex;
        }

        public static Texture2D GenerateCrossTexture(Color line) {
            Texture2D tex = new Texture2D(64, 64);
            Color[] cols = new Color[64 * 64];
            for (int y = 0; y < 64; y++) {
                for (int x = 0; x < 64; x++) {
                    Color col = line;
                    if (y != 31 && x != 31) col.a = 0;
                    cols[(y * 64) + x] = col;
                }
            }
            tex.SetPixels(cols);
            tex.wrapMode = TextureWrapMode.Clamp;
            tex.filterMode = FilterMode.Bilinear;
            tex.name = "Grid";
            tex.Apply();
            return tex;
        }
    }
}