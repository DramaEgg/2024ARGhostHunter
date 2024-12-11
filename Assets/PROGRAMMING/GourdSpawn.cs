using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GourdSpawn : MonoBehaviour
{
    public GameObject monsterPrefab;     
    public Transform spawnArea;           
    public float spawnRadius = 10f;       
    public int maxMonsters = 3;         
    public float spawnInterval = 5f;
    public float spawnTime = 1f;

    private int currentMonsterCount = 0;
    int maxMonsterCount = 3;


   
    

    void Start()
    {
         InvokeRepeating(nameof(SpawnMonster), spawnTime, spawnInterval);
    }



    void SpawnMonster()
    {
        
        if (currentMonsterCount >= maxMonsters) return;

      
        Vector3 spawnPoint = GetRandomSpawnPoint();

        
        if (NavMesh.SamplePosition(spawnPoint, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            Instantiate(monsterPrefab, hit.position, Quaternion.identity);
            currentMonsterCount++;
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        randomPoint += spawnArea.position;
        randomPoint.y = spawnArea.position.y; 

        return randomPoint;
    }

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(spawnArea.position, spawnRadius);
    }
}
