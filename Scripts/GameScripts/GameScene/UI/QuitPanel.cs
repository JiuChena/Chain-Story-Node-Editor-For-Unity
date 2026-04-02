using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : PanelBase<QuitPanel>
{
    public CustomGUIButton btnClose;
    public CustomGUIButton btnYes;
    public CustomGUIButton btnNo;

    void Start()
    {
        btnClose.clickEvent += () =>
        {
            HidePanel();
            GamePanel.Instance.ShowPanel();
            Time.timeScale = 1;
        };
        btnYes.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };
        btnNo.clickEvent += () =>
        {
            HidePanel();
            GamePanel.Instance.ShowPanel();
            Time.timeScale = 1;
        };

        HidePanel();
    }
}
