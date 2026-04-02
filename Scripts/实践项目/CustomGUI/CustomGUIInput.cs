using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIInput : CustomGUICtrl
{
    public float x;
    public float y;
    public float width = 100;
    public float height = 50;
    public bool ButtonTurn = true;
    public GUIStyle btnStyle;
    public GUIContent btnContent;

    public event UnityAction LoadEvent;

    protected override void StyleOff()
    {
        content.text = GUI.TextField(GUIPos.Position, content.text);
        if (ButtonTurn)
        {
            if (GUI.Button(new Rect(GUIPos.Position.x + x, GUIPos.Position.y + y, width, height), btnContent))
            {
                LoadEvent?.Invoke();
            }
        }
    }

    protected override void StyleOn()
    {
        content.text = GUI.TextField(GUIPos.Position, content.text, style);
        if (ButtonTurn)
        {
            if (GUI.Button(new Rect(GUIPos.Position.x + x, GUIPos.Position.y + y, width, height), btnContent))
            {
                LoadEvent?.Invoke();
            }
        }
    }
}
