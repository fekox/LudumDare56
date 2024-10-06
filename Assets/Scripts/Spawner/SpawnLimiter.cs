using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLimiter : MonoBehaviour
{
    private int spawnCount=0;
    // Start is called before the first frame update
    [SerializeField] public int spawnLimit=20;

    [ContextMenu("AddCount")]
    public void AddCount()
    {
        spawnCount++;
    }

    [ContextMenu("DecreaseCount")]
    public void DecreaseCount()
    {
        spawnCount--;
    }


    [ContextMenu("SpawnLimitNotReached")]
    public bool SpawnLimitNotReached()
    {
        return (spawnCount < spawnLimit);
    }


}
