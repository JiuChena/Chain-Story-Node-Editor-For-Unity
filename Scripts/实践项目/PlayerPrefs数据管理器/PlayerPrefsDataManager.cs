using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
//using UnityEditor.Build.Content;
using UnityEngine;

//单例模式
/// <summary>
/// PlayerPrefs数据管理类，统一存储和读取
/// </summary>
public class PlayerPrefsDataManager
{
    #region 单例模式初始化
    public static PlayerPrefsDataManager instance = new PlayerPrefsDataManager();
    public PlayerPrefsDataManager Instance => instance;
    private PlayerPrefsDataManager() { }     //把构造函数私有化可以避免外部再去new一个新的对象
    #endregion

    #region 数据存储
    /// <summary>
    /// 数据存储
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="dataKey">数据对象自己的唯一key</param>
    public void SaveData(object data,string dataKey)
    {
        Type dataType = data.GetType();
        //得到存储数据对象的所有字段
        FieldInfo[] infos = dataType.GetFields();

        //存储规则：dataKey_数据类型_字段类型_字段名称
        string SaveDataKeyName = "";
        foreach (var item in infos)
        {
            SaveDataKeyName = dataKey + "_" + dataType.Name + "_" + item.FieldType.Name + "_" + item.Name;
            //意思是从哪个数据里面的字段获取值
            SaveValue(item.GetValue(data), SaveDataKeyName);
        }
    }
    private void SaveValue(object value,string keyName)
    {
        //判断数据类型选择不同的数据类型存储方式
        Type fieldType = value.GetType();
        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }

        //如何判断泛型类型，因为IList这个接口上有List的明显特征，所以通过IsAssignableFrom
        //来判断传入的数据类型是否是继承了IList，如果是那证明这个数据类型就是List
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            //父类装子类
            IList list = value as IList;
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (var item in list)
            {
                //此处还是不确定list内部存储数据的类型，那么把这个问题重新丢给SaveValue函数即可
                //keyName不能重复，所以可以在名字后面加上数据在list列表中的索引值
                SaveValue(item, keyName + index);
                index++;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dic = value as IDictionary;
            PlayerPrefs.SetInt(keyName, dic.Count);

            //键值对存储
            int index = 0; 
            foreach (var key in dic.Keys)
            {
                SaveValue(  key   , keyName + "_key_" + index);
                SaveValue(dic[key], keyName + "_value_" + index);
                index++;
            }
            #region 可以参考上面的代码
            //int valueIndex = 0;
            //foreach (var dicValue in dic.Values)
            //{
            //    SaveValue(dicValue, keyName + "_value_" + valueIndex);
            //    valueIndex++;
            //}
            #endregion
        }
        else
        {
            SaveData(value, keyName);
        }

    }
    #endregion

    #region 数据读取
    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取数据的数据类型</param>
    /// <param name="dataKey">数据对象的唯一key值</param>
    /// <returns></returns>
    public object LoadData(Type type, string dataKey)
    {
        //根据传入的type创建一个对象，用于存储读出的数据
        object data = Activator.CreateInstance(type);
        //得到所有字段
        FieldInfo[] infos = type.GetFields();
        string loadKeyName = "";
        foreach (var info in infos)
        {
            //读取的key的拼接规则一定要和存储的拼接规则一样
            loadKeyName = dataKey + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;
            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }


        return data;
    }
    private object LoadValue(Type fieldType, string keyName)
    {
        //根据字段类型来判断用哪个API读取
        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (fieldType == typeof(bool))
        {
            return (PlayerPrefs.GetInt(keyName) == 1 ? true : false);
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            int count = PlayerPrefs.GetInt(keyName);
            //使用反射中的Activator来快速实例化一个对象
            IList list = Activator.CreateInstance(fieldType) as IList;
            for(int i = 0; i < count; i++)
            {
                //通过反射中的GetGenericArguments可以得到泛型的类型，由于List<T>只有一种类型，所以取索引为0的类型
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int count = PlayerPrefs.GetInt(keyName);
            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;
            for(int i = 0; i < count; i++)
            {
                dic.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + "_key_" + i),
                    LoadValue(fieldType.GetGenericArguments()[1], keyName + "_value_" + i));
            }
            return dic;
        }
        else
        {
            return LoadData(fieldType, keyName);
        }
    }
    #endregion
}
