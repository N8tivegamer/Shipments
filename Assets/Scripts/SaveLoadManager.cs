using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{

    public static SaveLoadManager Instance { get; set; }

    public string highScoreKey = "BestWaveSaveValue"; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }


    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(highScoreKey, score);
    }


    public int LoadHighScore()
    {
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            return PlayerPrefs.GetInt(highScoreKey);
        }
        else 
        {
            return 0;
        }
    }
}
