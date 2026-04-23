using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance { get { return instance; } }

    public int highestWave = 0;


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
    }

    private void Start()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        SaveData data = SaveSystem.LoadPlayer();
        highestWave = data.highestWave;
    }

    public void SavePlayer() 
    {
        SaveSystem.SavePlayer(this);
    }


    private void OnApplicationQuit() => SavePlayer();
}
