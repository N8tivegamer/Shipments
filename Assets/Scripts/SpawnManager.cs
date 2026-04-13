using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private int cubesToSpawn = 5;

    private GameObject[] spawnPoints;

    public GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // Increase the difficulty for the next wave
            cubesToSpawn += 5;

            // Notify the GameManager to update the UI/Wave count
            // (Assumes you have a Singleton GameManager with a NextWave method)
            GameManager.Instance.NextWave();

            // Spawn the new, larger batch of enemies
            Spawn();
        }
    }


    private void Spawn()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No objects with the tag 'SpawnPoint' were found in the scene.");
            return;
        }

        // Loop from 0 up to cubesToSpawn
        for (int i = 0; i < cubesToSpawn; i++)
        {
            // Pick a random index from the spawnPoints array
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Get the transform (position and rotation) of the chosen spawn point
            Transform randomSpawnPoint = spawnPoints[randomIndex].transform;

            // Spawn the enemy at that random location and rotation
            Instantiate(enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
    }

}
