using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [ExecuteInEditMode]
    [AddComponentMenu("X Sound Node/SoundNodeGraph", 1)]
    [RequireNode(typeof(ExecuteEventNode), typeof(XSoundNodePlay), typeof(XSoundNodeSource))]
    [RequireComponent(typeof(ExecuteEventNode), typeof(XSoundNodePlay), typeof(XSoundNodeSource))]
    public class XSoundNodeGraph : FlowNodeGraph
    {
        private void Reset()
        {
            // Execute добавлен автоматически
            ExecuteEventNode start = GetComponent<ExecuteEventNode>();
            if (start != null)
            {
                start.graph = this;
                if (start.Name == null || start.Name.Trim() == "")
                {
                    start.Name = "Execute Event";
                }
                start.Position = new Vector2(-300.0f, -100.0f);
                EventToTestExecute = start.Name;
            }

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

            XSoundNodeSource source = GetComponent<XSoundNodeSource>();
            // Добавить Source и соединить с Play, а Play с Execute
            if (source != null)
            {
                source.Name = "Source";
                source.Position = new Vector2(-400.0f, 50.0f);

                OnBeforeSerialize();
                if (play != null)
                {
                    NodePort sourceOutput = source.GetOutputPort(nameof(source.audioOutput));
                    NodePort playInput = play.GetInputPort(nameof(play.audioInput));
                    if (sourceOutput != null && playInput != null)
                    {
                        sourceOutput.Connect(playInput);
                    }
                    if (start != null)
                    {
                        NodePort startFlowOutput = start.GetOutputPort(nameof(start.FlowOutput));
                        NodePort playFlowInput = play.GetInputPort(nameof(play.FlowInput));
                        if (startFlowOutput != null && playFlowInput != null)
                        {
                            startFlowOutput.Connect(playFlowInput);
                        }
                    }


                }
            }
        } 
    }
}
