using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   private static DataManager instance;

    public static DataManager Instance {  get { return instance; } }

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI pointsText;



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
        if (coinsText)
        {
            coinsText.text = "Coins:" + Player.Instance.coins;
        }
        if (pointsText)
        {
            pointsText.text = "Points:" + Player.Instance.points;
        }
    }





    void Update()
    {

        if (coinsText)
        {
            coinsText.text = "Coins:" + Player.Instance.coins;
        }
        if (pointsText)
        {
            pointsText.text = "Points:" + Player.Instance.points;
        }
    }
}
