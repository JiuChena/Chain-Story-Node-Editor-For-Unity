using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CustomGUIButton : CustomGUICtrl
{
    public event UnityAction clickEvent;
    
    protected override void StyleOff()
    {
        if (GUI.Button(GUIPos.Position, content))
        {
            clickEvent?.Invoke();
        }
    }

    protected override void StyleOn()
    {
        if (GUI.Button(GUIPos.Position, content, style))
        {
            clickEvent?.Invoke();
        }
    }
}
