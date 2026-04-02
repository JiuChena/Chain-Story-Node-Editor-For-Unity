using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomGUILabel : CustomGUICtrl
{
    protected override void StyleOff()
    {
        GUI.Label(GUIPos.Position, content);
    }

    protected override void StyleOn()
    {
        GUI.Label(GUIPos.Position, content, style);
    }
}
