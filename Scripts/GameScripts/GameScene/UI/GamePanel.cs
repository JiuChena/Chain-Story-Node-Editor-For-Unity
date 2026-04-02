using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : PanelBase<GamePanel>
{
    public CustomGUILabel labScore;
    public CustomGUILabel labTime;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUITexture texBlood;
    public CustomGUILabel labBloodShow;
    public AudioSource audioSource;
    public CustomGUILabel remainLab;
    public CustomGUILabel notice;
    public float BloodWidth = 200f;

    [HideInInspector]
    public float nowScore;
    [HideInInspector]
    public float nowTime;
    private float tempTime = 0;

    private void Start()
    {
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            HidePanel();
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            HidePanel();
            QuitPanel.Instance.ShowPanel();
            Time.timeScale = 0;
        };

        //初始化加载音频
        audioSource.clip = SettingPanel.Instance.audioClips[GameDataManger.Instance.musicData.index];
        audioSource.volume = GameDataManger.Instance.musicData.musicValue / 100;
        if (GameDataManger.Instance.musicData.onMusic)
        {
            audioSource.Play();
        }

    }
    private void Update()
    {
        nowTime += Time.deltaTime;
        tempTime += Time.deltaTime;
        #region 对time进行时分秒转换
        int time = (int)tempTime;
        string result = "";
        if (time / 3600 > 0)
        {
            result += time / 3600 + "h ";
            time %= 3600;
        }
        if (time / 60 > 0)
        {
            result += time / 60 + "min ";
            time %= 60;
        }
        if (time != 0)
        {
            result += time + "s";
        }
        #endregion
        labTime.content.text = result;
    }

    public void ScoreUpdate(float score)
    {
        nowScore = score;
        labScore.content.text = nowScore.ToString("F0");
    }

    public void BloodUpdate(float maxBlood,float Blood)
    {
        texBlood.GUIPos.Width = Blood / maxBlood * BloodWidth;
        labBloodShow.content.text = ((int)Blood).ToString();
    }

    public void RemainBullets(int use)
    {
        remainLab.content.text = (Int32.Parse(remainLab.content.text) - use).ToString();
    }

}
