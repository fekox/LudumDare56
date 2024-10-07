using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class spawnerGenerator : MonoBehaviour
{

    [SerializeField] private GameObject respawnPrefab;
    private GameObject[] respawnLocations;
    private List<GameObject> respawnLocationList;
    private bool[] respawnAvailable;


    [SerializeField] private float timeUntilSameSpotRespawn=30.0f;

    [SerializeField] private int intervalSpawn = 3;

    [SerializeField] public int spawnerLimit = 3;
    private float spawnCount = 0;
    void Start()
    {
        if (respawnLocations == null)
            respawnLocations = GameObject.FindGameObjectsWithTag("respawnLocation");
        respawnLocationList = new List<GameObject>(respawnLocations);



        StartCoroutine(SpawnSpawner(intervalSpawn, respawnPrefab));

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnSpawner(float interval, GameObject spawner)
    {
        yield return new WaitForSeconds(interval);



        if ((spawnCount < spawnerLimit) && (respawnLocationList.Count > 0))
        {
            GameObject nextSpawnerLocation = respawnLocationList[Random.Range(0, respawnLocationList.Count)];
            respawnLocationList.Remove(nextSpawnerLocation);
            spawnCount++;
            GameObject newSpawner = Instantiate(spawner, new Vector3(nextSpawnerLocation.transform.position.x, nextSpawnerLocation.transform.position.y, nextSpawnerLocation.transform.position.z), nextSpawnerLocation.transform.rotation, nextSpawnerLocation.transform);
        


        }

        StartCoroutine(SpawnSpawner(interval, spawner));
    }

    public void SpawnerDespawned(GameObject respawnLocation)
    {
        StartCoroutine(readdingToList(timeUntilSameSpotRespawn, respawnLocation));
        spawnCount--;
    }

    private IEnumerator readdingToList(float delay, GameObject respawnLocation)
    {
        yield return new WaitForSeconds(delay);
        respawnLocationList.Add(respawnLocation);
    }

    public void AddNewSpawner(GameObject respawnLocation)
    {
        respawnLocationList.Add(respawnLocation);
    }

}
