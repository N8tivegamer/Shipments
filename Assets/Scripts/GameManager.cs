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

    private void Awake()
    {
        // Setup the Singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the round and the UI text
        CurrentRound = 1;
        waveTxt.text = "Wave: " + CurrentRound.ToString();
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
