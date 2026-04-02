using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CustomRoot : MonoBehaviour
{
    private CustomGUICtrl[] AllScripts;

    //在此处统一绘制子对象控件内容
    private void OnGUI()
    {
        
        AllScripts = this.GetComponentsInChildren<CustomGUICtrl>();
        
        //遍历每一个脚本让其进行绘制
        foreach(CustomGUICtrl script in AllScripts)
        {
            script.DrawGUI();
        }
        
    }
}
