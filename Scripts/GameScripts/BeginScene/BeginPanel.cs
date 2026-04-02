using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : PanelBase<BeginPanel>
{
    //声明各个控件并且在Unity中把他们关联上去
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    public AudioSource audioSource;

    void Start()
    {
        //加载背景音乐
        audioSource.clip = SettingPanel.Instance.audioClips[GameDataManger.Instance.musicData.index];
        audioSource.volume = GameDataManger.Instance.musicData.musicValue / 100;
        if (GameDataManger.Instance.musicData.onMusic) audioSource.Play();

        #region 开始游戏
        btnBegin.clickEvent += () =>
            {
                SceneManager.LoadScene("GameScene");
                HidePanel();
                Time.timeScale = 1;
            };
        #endregion

        #region 进入设置
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            HidePanel();
        };
        #endregion

        #region 退出游戏
        btnQuit.clickEvent += () =>
        {
            Application.Quit();
        };
        #endregion

        #region 排行榜
        btnRank.clickEvent += () =>
        {
            HidePanel();
            RankPanel.Instance.ShowPanel();
        };
        #endregion


        //GameDataManger.Instance.AddRankInfo("作者", 1000, 5);
    }
}
