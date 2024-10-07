using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float health = 100;

    private spawnerGenerator respawnerGenerator;

    private SpawnLimiter spawnLimiter;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField] private float interval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnLimiter = GameObject.FindGameObjectWithTag("SpawnLimiter").GetComponent<SpawnLimiter>();
        StartCoroutine(SpawnEnemy(interval, enemyPrefab));
        
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        if (spawnLimiter.SpawnLimitNotReached())
        {
            spawnLimiter.AddCount();
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        }

        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    [ContextMenu("die")]
    public void SpawnerDie()
    {
        FindAnyObjectByType<AudioManager>().Play("DestroyObj");

        respawnerGenerator =GameObject.FindGameObjectWithTag("respawnerGenerator").GetComponent<spawnerGenerator>();

        respawnerGenerator.SpawnerDespawned(transform.parent.gameObject);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health==0)
        {
            SpawnerDie();
        }
    }

}
