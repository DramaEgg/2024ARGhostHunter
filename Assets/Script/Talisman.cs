using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 1f;
    public ParticleSystem TalismanParticleSystem;
    public Rigidbody TalismanRigidbody;


    private void Start()
    {

    }
    private void Awake()
    {
        TalismanRigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ghost")
        {
            TalismanParticleSystem.Play();
            Destroy(this, lifeTime);
        }
    }
    public void Fire(Vector3 direction)
    {
        if (TalismanRigidbody != null)
        {
            TalismanRigidbody.velocity = direction * speed;
        }
    }
}
