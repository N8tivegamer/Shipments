using System.Collections;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Enemy;

public class Enemy : MonoBehaviour, IDamageable<float>
{
    private Transform target;  // Storage for the Player's position
    private NavMeshAgent ai; // Reference to the AI component on this object

    public Transform PatrolPoint;

    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    public EnemyState enemyState;

    private Animator anim;
    private float distanceToTarget;
    private Coroutine idlerToPatrol;


    private float healthPoints = 50f;

    public void Damage(float damageTaken)
    {
        healthPoints -= damageTaken;

        if (healthPoints <= 0f)
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {



        enemyState = EnemyState.Idle;
        anim = GetComponent<Animator>();

        ai = GetComponent<NavMeshAgent>();
        // Locate the Player by looking for the "Player" tag and grab its Transform
        target = GameObject.FindWithTag("Player").transform;

        distanceToTarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));


        PatrolPoint = GameObject.FindWithTag("Patrol").transform;
    }

    IEnumerator SwitchToPatrol()
    {
        yield return new WaitForSeconds(5);
        enemyState = EnemyState.Patrol;
        idlerToPatrol = null;
    }


    private void SwitchState(int newState)
    {
        if (anim.GetInteger("State") != newState)
        {
            anim.SetInteger("State", newState);
        }
    }



    // Update is called once per frame
    void Update()
    {
        // Tell the NavMeshAgent to calculate a path and move toward the player's current position
        ai.SetDestination(target.position);


        distanceToTarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));

        switch (enemyState)
        {
            case EnemyState.Idle:
                SwitchState(0);
                ai.SetDestination(transform.position);

                if (idlerToPatrol == null)
                {
                    idlerToPatrol = StartCoroutine(SwitchToPatrol());
                }
                break;

            case EnemyState.Patrol:
                float distanceToPatrolPoint = Mathf.Abs(Vector3.Distance(PatrolPoint.position, transform.position));

                if (distanceToPatrolPoint > 2)
                {
                    SwitchState(1);
                    ai.SetDestination(PatrolPoint.position);
                }
                else
                {
                    SwitchState(0);
                }

                if (distanceToTarget <= 15)
                {
                    enemyState = EnemyState.Chase;
                }
                break;

            case EnemyState.Chase:
                SwitchState(2);

                // Move toward the target
                ai.SetDestination(target.position);

                if (distanceToTarget <= 5)
                {
                    enemyState = EnemyState.Attack;
                }
                else if (distanceToTarget > 15)
                {
                    enemyState = EnemyState.Idle;
                }
                break;
            case EnemyState.Attack:
                SwitchState(3);

                if (distanceToTarget > 5 && distanceToTarget <= 15)
                {
                    enemyState = EnemyState.Chase;
                }
                else if (distanceToTarget > 15)
                {
                    enemyState = EnemyState.Idle;
                }
                break;

            default:
                break;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if we hit the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage the player
            PlayerManager.Instance.Damage(20f);                              

            // Destroy this enemy
            Destroy(gameObject);
        }
    }

    public void damage (float damageTaken)
    {
        healthPoints -= damageTaken;

        if (healthPoints <= 0f)
        {
            Die();
        }
    }


    void Die() 
    {
        Destroy(gameObject);
    }
} 
