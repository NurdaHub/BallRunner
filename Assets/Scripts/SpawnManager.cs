using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bonusPrefab;
    
    private float spawnRangeX = 3.5f;
    private float spawnPosZ = 10;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private int poolObjectsCount = 5;

    private Pool enemyPool;
    private Pool bonusPool;
    private List<Pool> pools = new List<Pool>();

    private void Start()
    {
        CreatePool();
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    private void CreatePool()
    {
        enemyPool = new Pool(enemyPrefab, poolObjectsCount, transform);
        bonusPool = new Pool(bonusPrefab, poolObjectsCount, transform);
        pools.Add(enemyPool);
        pools.Add(bonusPool);
    }

    private void SpawnRandomObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int poolIndex = Random.Range(0, pools.Count);
        
        GameObject currentObject = pools[poolIndex].GetFreeElement();
        currentObject.transform.position = spawnPosition;
        currentObject.SetActive(true);
    }

    public void DeactivateAllPools()
    {
        foreach (var pool in pools)
        {
            pool.DeactivateAllElements();
        }
    }
}
