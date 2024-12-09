using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
   public GameObject GhostPreFab;
   public Transform ghostSpawnPos;

    bool hasSpawned = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&!hasSpawned)
        {
            Instantiate(GhostPreFab, ghostSpawnPos.position, ghostSpawnPos.rotation);
            Debug.Log("Monster spawned at: " + ghostSpawnPos.position);
            hasSpawned = true;
        }
    }

}
