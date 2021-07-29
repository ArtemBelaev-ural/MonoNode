using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace FlowNodes
{
    [ExecuteInEditMode]
    [AddComponentMenu("X Sound Node/SoundNodeGraph", 1)]
    [RequireNode(typeof(XSoundNodePlay))]
    [RequireComponent(typeof(XSoundNodePlay))]
    public class XSoundNodeGraph : FlowNodeGraph
    {
        private void Reset()
        {
            // Play добавлен автоматически
            XSoundNodePlay play = GetComponent<XSoundNodePlay>();
            if (play != null)
            {
                play.graph = this;
                if (play.Name == null || play.Name.Trim() == "")
                {
                    play.Name = "Play";
                }
                play.Position = new Vector2(100.0f, -50.0f);
            }

            // ƒобавить Source и соединить с Play
            if (GetComponent<XSoundNodeSource>() == null)
            {
                MonoNode.graphHotfix = this;
                var source = AddNode<XSoundNodeSource>();
                MonoNode.graphHotfix = null;
                source.Name = "Source";
                source.Position = new Vector2(-400.0f, -50.0f);

                OnBeforeSerialize();
                if (NodesCount == 2)
                {
                    NodePort output = source.GetOutputPort(nameof(source.audioOutput));
                    NodePort input = play.GetInputPort(nameof(play.audioInput));
                    if (output != null && input != null)
                    {
                        output.Connect(input);
                    }

                }
            }
            NodeToTestExecute = ALL_NODES;
        } 
    }
}
