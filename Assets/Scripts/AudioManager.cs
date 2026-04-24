using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    public static AudioManager Instance {  get { return instance; } }

    public AudioMixer masterMixer;

    public Slider muiscSlider, masterSlide;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);  
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        masterMixer.SetFloat("MasterVol", PerferenceManager.GetMasterVolume());
        masterMixer.SetFloat("MusicVol", PerferenceManager.GetMusicVolume());

        if (muiscSlider != null) 
         PerferenceManager.GetMusicVolume();

        if (masterSlide != null)
            PerferenceManager.GetMasterVolume();
    }

    public void ChangeSoundVolume(float soundLevel)
    {
        masterMixer.SetFloat("MasterVol", soundLevel);
        PerferenceManager.SetMasterVolume(soundLevel);
    }
    public void ChangeMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("MusicVol", soundLevel);
        PerferenceManager.SetMusicVolume(soundLevel);
    }
  

}
