using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance {  get { return instance; } }


    public int points = 0;
    public int coins = 0;
    public int currentBlaster = 0;
    public int highestWave = 0;
    public string playerName = "Playername";
    public int[] ownedBlaster = { 1, 0, 0, 0, 0, 0, 0 };



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
}
