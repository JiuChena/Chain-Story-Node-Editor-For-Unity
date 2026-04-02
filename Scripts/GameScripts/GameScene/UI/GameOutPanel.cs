using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOutPanel : PanelBase<GameOutPanel>
{
    public CustomGUIButton btnYes;
    public CustomGUIButton btnNo;

    private void Start()
    {
        btnYes.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
            SceneManager.LoadScene("GameScene");
        };
        btnNo.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };

        HidePanel();
    }
}
