using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : PanelBase<SettingPanel>
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderAcoustics;
    public CustomGUIToggle toggleMusic;
    public CustomGUIToggle toggleAcoustics;
    
    public CustomGUIButton btnClose;

    public CustomGUILabel textShow;

    public CustomGUIButton btnChangeMusic;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private AudioSource audioSound;
    
    void Start()
    {
        sliderMusic.changeValue += (value) =>
        {
            audioSource.volume = value / 100;
            textShow.content.text = "Music Voice : " + value.ToString("F1");
            GameDataManger.Instance.MusicValue(value);
        };
        toggleMusic.changeEvent += (select) =>
        {
            if (select) audioSource.UnPause();
            else audioSource.Pause();
            textShow.content.text = "Music : " + (select ? "On" : "Off");
            GameDataManger.Instance.OnMusic(select);
        };

        sliderAcoustics.changeValue += (value) =>
        {
            textShow.content.text = "Acoustics Voice : " + value.ToString("F1");
            GameDataManger.Instance.SoundValue(value);
        };
        toggleAcoustics.changeEvent += (select) =>
        {
            textShow.content.text = "Acoustics : " + (select ? "On" : "Off");
            GameDataManger.Instance.OnSound(select);
        };

        btnClose.clickEvent += () =>
        {
            HidePanel();
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowPanel();
            }
            else
            {
                GamePanel.Instance.ShowPanel();
            }
            Time.timeScale = 1;
        };

        btnChangeMusic.clickEvent += () =>
        {
            int index = GameDataManger.Instance.musicData.index + 1;
            if (index >= audioClips.Length) index = 0;
            audioSource.clip = audioClips[index];
            audioSource.Play();
            textShow.content.text = "NowMusic : " + audioClips[index].name;
            GameDataManger.Instance.MusicIndex(index);
        };

        HidePanel();
    }
    public void UpDataPanelInfo()
    {
        MusicData data = GameDataManger.Instance.musicData;
        sliderMusic.nowValue = data.musicValue;
        sliderAcoustics.nowValue = data.soundValue;
        toggleMusic.IsSelelct = data.onMusic;
        toggleAcoustics.IsSelelct = data.onSound;
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
        UpDataPanelInfo();
    }
}
