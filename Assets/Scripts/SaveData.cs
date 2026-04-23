using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    
    public int  highestWave;
   


    public SaveData(Player player) 
    {
        highestWave = player.highestWave;
        
    }



    public SaveData()
    {
        highestWave = 0;

    }
}
