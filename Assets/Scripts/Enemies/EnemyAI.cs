using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    private SpawnLimiter spawnLimiter;

    [SerializeField] private PlayerHealth playerHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        spawnLimiter = GameObject.FindGameObjectWithTag("SpawnLimiter").GetComponent<SpawnLimiter>();
    }

    void Update()
    {
        Chase();
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
        NavMeshAgent nma = GetComponent<NavMeshAgent>();
        Vector3 v3Velocity = nma.velocity;
        transform.rotation = Quaternion.LookRotation(v3Velocity);
    }

    [ContextMenu("die")]
    public void Die()
    {
        FindAnyObjectByType<AudioManager>().Play("AntKilled");
        spawnLimiter.DecreaseCount();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WeaponCollider"))
        {
            PlayerPointsSystem pointsSystem = player.GetComponent<PlayerPointsSystem>();

            pointsSystem.AddPoints(pointsSystem.GetPointsPerAnt());

            Die();
        }

        if (other.CompareTag("Player"))
        {
            if (!player.GetComponent<PlayerHealth>().GetIsTakingDamage())
            {
                player.GetComponent<PlayerHealth>().AddOneAnt(gameObject.transform.position);
            }

            Die();
        }
    }
}