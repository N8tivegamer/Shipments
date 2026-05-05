using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Singleton pattern to allow Spawner.cs to access GameManager.Instance
    public static GameManager Instance { get; private set; }

    // Private static property with automatic getter and setter
    public static int CurrentRound { get; private set; }

    // Public reference for the UI text
    public TextMeshProUGUI waveTxt;

    public int currentPoints;

    public GameObject gameOverScreen;

    public int highScore;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);

        }
        else
        { Instance = this; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the round and the UI text
        CurrentRound = 1;

        gameOverScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }



    public void GameOver()
    {
        Time.timeScale = 0f;


        // Show Game Over UI
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }


    public void GoHome()
    {
        Time.timeScale = 1f;

        SceneLoader.ToMainMenu();
    }

    public void Restart()
    {
        // Unfreeze time before restarting
        Time.timeScale = 1f;

        SceneLoader.PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        //Keep the text updated every frame
        waveTxt.text = "Wave: " + CurrentRound.ToString();
    }

    public void NextWave()
    {
        CurrentRound++;
        if (CurrentRound >= highScore)
        {
            Player.Instance.highestWave = CurrentRound;
            Player.Instance.SavePlayer();

        }

    }

}
