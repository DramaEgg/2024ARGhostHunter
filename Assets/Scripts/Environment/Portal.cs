 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform Tp;
    public GameObject Player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds (0);
        Player.transform.position = new Vector3(Tp.transform.position.x, Tp.transform.position.y, Tp.transform.position.z);
    }
}
