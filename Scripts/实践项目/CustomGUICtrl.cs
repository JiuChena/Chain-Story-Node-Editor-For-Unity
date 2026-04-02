using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomGUICtrl : MonoBehaviour
{
    //控件位置
    public CustomGUIpos GUIPos;

    //显示内容信息
    public GUIContent content;
    public GUIStyle style;

    //自定义样式是否启用
    public bool StyleTurn = true;

    //提供给外部绘制控件的方法
    public void DrawGUI()
    {
        if(StyleTurn)   StyleOn();
        else    StyleOff();
    }

    protected abstract void StyleOn();
    protected abstract void StyleOff();
}
