using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;  // Storage for the Player's position
    private NavMeshAgent ai; // Reference to the AI component on this object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Link the 'ai' variable to the NavMeshAgent component attached to this GameObject
        ai = GetComponent<NavMeshAgent>();

        // Locate the Player by looking for the "Player" tag and grab its Transform
        target = GameObject.FindWithTag("Player") .transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Tell the NavMeshAgent to calculate a path and move toward the player's current position
        ai.SetDestination(target.position);
    }
}
