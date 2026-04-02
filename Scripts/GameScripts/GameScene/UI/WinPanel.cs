using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : PanelBase<WinPanel>
{
    public CustomGUIButton btnCompelet;
    public CustomGUIInput input;

    private void Start()
    {
        btnCompelet.clickEvent += () =>
        {
            GameDataManger.Instance.AddRankInfo(input.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            SceneManager.LoadScene("BeginScene");
            Time.timeScale = 1;
        };

        HidePanel();
    }
}
