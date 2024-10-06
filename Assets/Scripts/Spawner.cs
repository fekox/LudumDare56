using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

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

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (spawnLimiter.SpawnLimitNotReached())
        {
            spawnLimiter.AddCount();
            GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        }

        StartCoroutine(SpawnEnemy(interval, enemy));
    }

}
