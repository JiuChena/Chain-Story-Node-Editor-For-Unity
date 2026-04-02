using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{
    //Unity提供支持的鼠标图片格式
    public Texture2D tex;

    void Start()
    {
        //参数一填鼠标图片，参数二相对于鼠标左上角偏移位置，参数三平台支持光标模式（一般默认）
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
        {
            //不能直接切换，需要在building setting里面把场景加载到场景列表中
            SceneManager.LoadScene("Scene2");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            //退出游戏，但是在编辑模式下没有作用，一定要等到打包发布之后才有用
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;  //把鼠标指针限制在窗口范围内
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;   //把鼠标锁定在屏幕中心点
        }
    }
}
