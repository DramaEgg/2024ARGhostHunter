using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : MonoBehaviour
{
    public float TalismanSpeed = 3f;
    public float lifeTime = 5f;
    public float hitLifeTime = 1f;
    //public GameObject TalismanPrefab;
    public ParticleSystem TalismanParticleSystem;
    public Rigidbody TalismanRigidbody;

    private void Awake()
    {
        TalismanRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        TalismanRigidbody.velocity = transform.forward * TalismanSpeed;
    }
    public void Update()
    {
        Destroy(gameObject,lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            TalismanParticleSystem.Play();
            Destroy(gameObject,hitLifeTime);
        }
    }
}
