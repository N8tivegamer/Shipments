using System;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

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

    
    private void Awake()
    {
        if (Instance != null && Instance != this )
        {
            Destroy(this.gameObject);

        }
        else
        {Instance = this; }    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the round and the UI text
        CurrentRound = 1;
        waveTxt.text = "Wave: " + CurrentRound.ToString();


        gameOverScreen.SetActive(false);
    }



    public void GameOver()
    {
        Time.timeScale = 0f;

        // Show Game Over UI
        gameOverScreen.SetActive(true);
    }


    public void GoHome()
    {
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
    }

}
