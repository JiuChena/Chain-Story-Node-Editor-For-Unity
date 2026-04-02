using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomGUIToggle : CustomGUICtrl
{
    public bool IsSelelct;
    private bool OldSelelct;

    public UnityAction<bool> changeEvent;

    protected override void StyleOff()
    {
        IsSelelct = GUI.Toggle(GUIPos.Position, IsSelelct, content);
        if (OldSelelct != IsSelelct)
        {
            changeEvent?.Invoke(IsSelelct);
            OldSelelct = IsSelelct;
        }
    }
    protected override void StyleOn()
    {
        IsSelelct = GUI.Toggle(GUIPos.Position, IsSelelct, content, style);
        if (OldSelelct != IsSelelct)
        {
            changeEvent?.Invoke(IsSelelct);
            OldSelelct = IsSelelct;
        }
    }
    
}
