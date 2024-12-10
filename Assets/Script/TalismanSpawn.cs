using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalismanSpawn : MonoBehaviour

{
    [Header("Prefab Settings")]
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float spawnInterval = 5f; 

    [Header("Spawn Area Settings")]
    [SerializeField] private float xMin = -15f; 
    [SerializeField] private float xMax = 15f;
    [SerializeField] private float zMin = -15f;
    [SerializeField] private float zMax = 15f; 
    [SerializeField] private float spawnHeight = 1.5f;

    [Header("Advanced Settings")]
    [SerializeField] private bool useSpawnPoints = false;
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private bool randomRotation = true; 
    [SerializeField] private int maxPrefabs = 2;

    private int currentPrefabCount = 0;
    private bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnPrefabRoutine());
    }

    IEnumerator SpawnPrefabRoutine()
    {
        while (isSpawning)
        {
            if (maxPrefabs > 0 && currentPrefabCount >= maxPrefabs)
            {
                yield break;
            }

            SpawnPrefab();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPrefab()
    {
        Vector3 spawnPosition;

        if (useSpawnPoints && spawnPoints != null && spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[randomIndex].position;
        }
        else
        {
            float randomX = Random.Range(xMin, xMax);
            float randomZ = Random.Range(zMin, zMax);
            spawnPosition = new Vector3(randomX, spawnHeight, randomZ);
        }

        Quaternion rotation = randomRotation ?
            Quaternion.Euler(0, Random.Range(0, 360), 0) :
            Quaternion.identity;

        GameObject spawnedPrefab = Instantiate
            (
            prefabToSpawn,
            spawnPosition,
            rotation
            );

        currentPrefabCount++;
    }



    // 公共方法用于控制生成
    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnPrefabRoutine());
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void ResetSpawnCount()
    {
        currentPrefabCount = 0;
    }

    // 在Scene视图中显示生成范围
    void OnDrawGizmos()
    {
        if (!useSpawnPoints)
        {
            Gizmos.color = Color.yellow;
            Vector3 center = new Vector3(
                (xMin + xMax) / 2,
                spawnHeight,
                (zMin + zMax) / 2
            );
            Vector3 size = new Vector3(
                xMax - xMin,
                0.1f,
                zMax - zMin
            );
            Gizmos.DrawWireCube(center, size);
        }
        else if (spawnPoints != null)
        {
            Gizmos.color = Color.green;
            foreach (Transform point in spawnPoints)
            {
                if (point != null)
                    Gizmos.DrawSphere(point.position, 0.5f);
            }
        }
    }
}
