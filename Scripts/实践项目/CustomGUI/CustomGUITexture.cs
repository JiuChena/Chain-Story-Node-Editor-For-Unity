using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUITexture : CustomGUICtrl
{
    public ScaleMode scale = ScaleMode.StretchToFill;
    protected override void StyleOff()
    {
        GUI.DrawTexture(GUIPos.Position, content.image, scale);
    }

    protected override void StyleOn()
    {
        GUI.DrawTexture(GUIPos.Position, content.image, scale);
    }
}
