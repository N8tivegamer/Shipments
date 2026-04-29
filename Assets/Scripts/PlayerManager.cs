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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("firstaid"))
        {
            Destroy(other.gameObject);
            healthPoints += 30;
            if (healthPoints > 100)
            {
                healthPoints = 100;
            }
        }
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(player);
    }

    // Updates total points
   

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

   
    }

    public void Damage(float damageTaken)
    {
        healthPoints -= damageTaken;
    }
}
