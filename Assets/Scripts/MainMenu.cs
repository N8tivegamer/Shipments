using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_Text highScoreUI;

    string newGameScene = "shipments";

    public Slider muiscSlider, masterSlide, SFXSlide;

    void Start()
    {
        int highScore = Player.Instance.highestWave;
        highScoreUI.text = $"Top Wave Survived: {highScore}";

        if (muiscSlider != null)
           muiscSlider.value = PerferenceManager.GetMusicVolume();

        if (masterSlide != null)
           masterSlide.value =  PerferenceManager.GetMasterVolume();

        if (SFXSlide != null)
           masterSlide.value =  PerferenceManager.GetSFXVolume();
    }

    public void ChangeSoundVolume(float soundLevel)
    {
       AudioManager.Instance.ChangeSoundVolume(soundLevel);
    }
    public void ChangeMusicVolume(float soundLevel)
    {
        AudioManager.Instance.ChangeMusicVolume(soundLevel);
    }
    public void ChangeSFXVolume(float soundLevel)
    {
        AudioManager.Instance.ChangeSFXVolume(soundLevel);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }


    public void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
    Application.Quit();

#endif


    }

}
