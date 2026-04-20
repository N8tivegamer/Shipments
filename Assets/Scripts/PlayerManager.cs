using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IDamageable<float>
{

    private Player player;
    private int currentPoints;


    public static PlayerManager Instance { get; private set; }
       
    private float healthPoints = 100f;

    public Slider healthBar;

    private void Awake()
    {
        Instance = this;
    }


    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(player);
    }

    // Updates total points
    private void UpdateTotalPoints()
    {
        player.points += currentPoints;
        currentPoints = 0;

    }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        player = Player.Instance;
        healthBar.value = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = healthPoints;

        // Check for death
        if (healthPoints <= 0f)
        {
            GameManager.Instance.GameOver();
        }

        if (currentPoints > 0)
        {
            UpdateTotalPoints();
            SavePlayerData();
        }

    }

    public void Damage(float damageTaken)
    {
        healthPoints -= damageTaken;
    }
}
