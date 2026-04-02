using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_Type
{
    Horizontal,
    Vertical,
}

public class CustomGUISlider : CustomGUICtrl
{
    private float maxValue = 100;
    private float minValue = 0;
    public float nowValue = 0;
    //{
    //    get
    //    {
    //        if (nowValue < minValue)
    //        {
    //            return minValue;
    //        }
    //        if (nowValue > maxValue)
    //        {
    //            return maxValue;
    //        }
    //        return nowValue;
    //    }
    //    set
    //    {
    //        if (nowValue < minValue)
    //        {
    //            nowValue = minValue;
    //        }
    //        if (nowValue > maxValue)
    //        {
    //            nowValue = maxValue;
    //        }
    //    }
    //}
    public GUIStyle ThumbStyle;
    public E_Type type;

    public event UnityAction<float> changeValue;
    private float oldValue;

    protected override void StyleOff()
    {
        switch (type)
        {
            case E_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(GUIPos.Position, nowValue, minValue, maxValue);
                break;
            case E_Type.Vertical:
                nowValue = GUI.VerticalSlider(GUIPos.Position, nowValue, minValue, maxValue);
                break;
        }
        if (nowValue != oldValue)
        {
            changeValue?.Invoke(nowValue);
        }
        oldValue = nowValue;
    }

    protected override void StyleOn()
    {
        switch (type)
        {
            case E_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(GUIPos.Position, nowValue, minValue, maxValue, style, ThumbStyle);
                break;
            case E_Type.Vertical:
                nowValue = GUI.VerticalSlider(GUIPos.Position, nowValue, minValue, maxValue, style, ThumbStyle);
                break;
        }
        if (nowValue != oldValue)
        {
            changeValue?.Invoke(nowValue);
        }
        oldValue = nowValue;
    }
}
