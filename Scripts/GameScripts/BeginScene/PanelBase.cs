using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase<T> : MonoBehaviour where T : class
{
    private static T instance;
    public static T Instance => instance;

    public Transform[] gameObjects;

    //protected PanelBase() { }

    private void Awake()
    {
        #region 解释
        //此处instance的类型是T，this的类型是BasePanel，并且as关键字只能在类
        //身上使用，所以这里需要加一个泛型约束，加上where : class
        //普通的单例模式自己在类型中去new一个对象传出去达到单个对象的目的
        //那么在这里Mono不允许我们自己去new一个对象，我们就认定脚本所依附的那个对象为
        //单例模式的对象
        #endregion
        instance = this as T;
    }
    private void Start()
    {
        gameObjects = this.GetComponentsInChildren<Transform>();
    }

    /// <summary>
    /// 面板显示
    /// </summary>
    public virtual void ShowPanel()
    {
        this.gameObject.SetActive(true);
        foreach(var item in gameObjects)
        {
            item.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
        foreach (var item in gameObjects)
        {
            item.gameObject.SetActive(false);
        }
    }
}
