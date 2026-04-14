using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IDamageable<float>
{

    public static PlayerManager Instance { get; private set; }
       
    private float healthPoints = 100f;

    public Slider healthBar;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
