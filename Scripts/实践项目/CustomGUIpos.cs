using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Alignment
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Right_Up,
    Left_Down,
    Right_Down,
}
/// <summary>
/// 计算位置类
/// </summary>
[System.Serializable]
public class CustomGUIpos 
{
    //每个控件实际的位置和尺寸初始化
    private Rect RealPos = new Rect(0, 0, 0, 0);
    //控件宽高设置
    public float Width;
    public float Height;
    //控件偏移量设置
    public Vector2 Offset;
    //控件中心点选择
    public E_Alignment CtrlAlignment = E_Alignment.Center;
    private Vector2 CtrlOffset;
    //屏幕区域点选择
    public E_Alignment ScreenAlignment = E_Alignment.Center;

    //控件中心点选择计算
    private void CtrlCenterSelect()
    {
        switch (CtrlAlignment)
        {
            case E_Alignment.Up:
                CtrlOffset.x = -Width / 2;
                CtrlOffset.y = 0;
                break;
            case E_Alignment.Down:
                CtrlOffset.x = -Width / 2;
                CtrlOffset.y = -Height;
                break;
            case E_Alignment.Left:
                CtrlOffset.x = 0;
                CtrlOffset.y = -Height / 2;
                break;
            case E_Alignment.Right:
                CtrlOffset.x = -Width;
                CtrlOffset.y = -Height / 2;
                break;
            case E_Alignment.Center:
                CtrlOffset.x = -Width / 2;
                CtrlOffset.y = -Height / 2;
                break;
            case E_Alignment.Left_Up:
                CtrlOffset.x = 0;
                CtrlOffset.y = 0;
                break;
            case E_Alignment.Right_Up:
                CtrlOffset.x = -Width;
                CtrlOffset.y = 0;
                break;
            case E_Alignment.Left_Down:
                CtrlOffset.x = 0;
                CtrlOffset.y = -Height / 2;
                break;
            case E_Alignment.Right_Down:
                CtrlOffset.x = -Width;
                CtrlOffset.y = -Height;
                break;
        }
    }
    
    //最终控件坐标计算
    private void CtrlPosition()
    {
        switch (ScreenAlignment)
        {
            case E_Alignment.Up:
                RealPos.x = Screen.width / 2 + CtrlOffset.x + Offset.x;
                RealPos.y = 0 + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Down:
                RealPos.x = Screen.width / 2 + CtrlOffset.x + Offset.x;
                RealPos.y = Screen.height + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Left:
                RealPos.x = 0 + CtrlOffset.x + Offset.x;
                RealPos.y = Screen.height / 2 + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Right:
                RealPos.x = Screen.width + CtrlOffset.x + Offset.x;
                RealPos.y = Screen.height / 2 + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Center:
                RealPos.x = Screen.width / 2 + CtrlOffset.x + Offset.x;
                RealPos.y = Screen.height / 2 + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Left_Up:
                RealPos.x = 0 + CtrlOffset.x + Offset.x;
                RealPos.y = 0 + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Right_Up:
                RealPos.x = Screen.width + CtrlOffset.x + Offset.x;
                RealPos.y = 0 + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Left_Down:
                RealPos.x = 0 + CtrlOffset.x + Offset.x;
                RealPos.y = Screen.height + CtrlOffset.y + Offset.y;
                break;
            case E_Alignment.Right_Down:
                RealPos.x = Screen.width + CtrlOffset.x + Offset.x;
                RealPos.y = Screen.height + CtrlOffset.y + Offset.y;
                break;
        }
    }

    public Rect Position
    {
        get
        {
            //利用构造函数设置控件宽高
            RealPos.width = Width;
            RealPos.height = Height;

            CtrlCenterSelect();
            CtrlPosition();
            return RealPos;
        }
    }
}

