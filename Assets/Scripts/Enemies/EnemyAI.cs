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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        spawnLimiter = GameObject.FindGameObjectWithTag("SpawnLimiter").GetComponent<SpawnLimiter>();

    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }

    [ContextMenu("die")]
    public void Die()
    {
        spawnLimiter.DecreaseCount();
        Destroy(gameObject);
    }

}
