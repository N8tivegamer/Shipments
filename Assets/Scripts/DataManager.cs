using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   private static DataManager instance;

    public static DataManager Instance {  get { return instance; } }



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


    void Start()
    {
        
    }





    void Update()
    {

    }
}
