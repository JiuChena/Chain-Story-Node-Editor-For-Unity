using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 游戏数据单例模式管理类
/// </summary>
public class GameDataManger
{
    //音乐数据
    private static GameDataManger instance = new GameDataManger();
    public static GameDataManger Instance => instance;
    public MusicData musicData;
    //排行榜数据
    public RankList rankData;
    private GameDataManger()
    {
        //PlayerPrefsDataManager.instance.DelData();
        //初始化游戏数据
        musicData = PlayerPrefsDataManager.instance.LoadData(typeof(MusicData), "Music") as MusicData;

        if (!musicData.LoadGameFirst)
        {
            musicData.LoadGameFirst = true;
            musicData.onMusic = true;
            musicData.onSound = true;
            musicData.musicValue = 50f;
            musicData.soundValue = 50f;
            musicData.index = 0;

            PlayerPrefsDataManager.instance.SaveData(musicData, "Music");
        }

        //初始化读取排行榜数据
        rankData = PlayerPrefsDataManager.instance.LoadData(typeof(RankList), "RankList") as RankList;
    }

    public void AddRankInfo(string name , float score , float time)
    {
        rankData.rankList.Add(new RankInfo(name,score,time));
        rankData.rankList.Sort((a, b) => (a.score/a.time) > (b.score/b.time) ? -1 : 1);
        for (int i = rankData.rankList.Count - 1; i >= 10; i--) 
        {
            rankData.rankList.RemoveAt(i);
        } 
        PlayerPrefsDataManager.instance.SaveData(rankData, "RankList");
    }

    //提供一些API给外部方便数据存储
    public void OnMusic(bool select)
    {
        musicData.onMusic = select;
        PlayerPrefsDataManager.instance.SaveData(musicData, "Music");
    }
    public void OnSound(bool select)
    {
        musicData.onSound = select;
        PlayerPrefsDataManager.instance.SaveData(musicData, "Music");
    }
    public void MusicValue(float value)
    {
        musicData.musicValue = value;
        PlayerPrefsDataManager.instance.SaveData(musicData, "Music");
    }
    public void SoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataManager.instance.SaveData(musicData, "Music");
    }
    public void MusicIndex(int index)
    {
        musicData.index = index;
        PlayerPrefsDataManager.instance.SaveData(musicData, "Music");
    }
}
