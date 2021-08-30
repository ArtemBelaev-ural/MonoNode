using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XMonoNode;

namespace XMonoNode
{
    [ExecuteInEditMode]
    [AddComponentMenu("X Sound Node/SoundNodeGraph", 1)]
    [RequireNode(typeof(OnFlowEventNode), typeof(XSoundNodePlay), typeof(FlowEnd))]
    [RequireComponent(typeof(OnFlowEventNode), typeof(XSoundNodePlay), typeof(FlowEnd))]
    public class XSoundNodeGraph : FlowNodeGraph
    {
        private void Reset()
        {
            // OnFlowStart добавлен автоматически
            OnFlowEventNode start = GetComponent<OnFlowEventNode>();
            if (start != null)
            {
                start.graph = this;
                if (start.Name == null || start.Name.Trim() == "")
                {
                    start.Name = "OnFlowStart";
                }
                start.Position = new Vector2(-300.0f, -100.0f);
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

            XSoundNodeSource source = gameObject.AddComponent<XSoundNodeSource>();
            // Добавить Source и соединить с Play, а Play с Flow
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

            // OnFlowStart добавлен автоматически
            FlowEnd end = GetComponent<FlowEnd>();
            if (end != null)
            {
                end.graph = this;
                if (end.Name == null || end.Name.Trim() == "")
                {
                    end.Name = "FlowEnd";
                }
                end.Position = new Vector2(450.0f, -100.0f);

                if (play != null)
                {
                    NodePort playEnd = play.GetOutputPort(nameof(play.onEnd));
                    NodePort endFlowInput = end.GetInputPort(nameof(play.FlowInput));
                    if (endFlowInput != null && playEnd != null)
                    {
                        playEnd.Connect(endFlowInput);
                    }
                }
            }
        } 
    }
}
