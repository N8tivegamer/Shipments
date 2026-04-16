using UnityEngine;

public class SaveData : MonoBehaviour
{
    public string playerName;
    public int coins;
    public int points;
    public int  highestWave;
    public int  currentBlaster;
    public int[] ownedBlaster;


    public SaveData(Player player) 
    {
        playerName = player.name;
        coins = player.coins;
        points = player.points;
        highestWave = player.highestWave;
        currentBlaster = player.currentBlaster;
        ownedBlaster = player.ownedBlaster;

            
    }

}
