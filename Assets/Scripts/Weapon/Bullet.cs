using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("BulletSetting")]
    public SOWeapon currentWeapon;
    public Rigidbody BulletRigidbody;
    public Transform HitParticleSystem;
    public Transform BloodParticleSystem;
    public Transform PlayerBloodParticleSystem;

    private void Awake()
    {
        BulletRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        BulletRigidbody.velocity = transform.forward * currentWeapon.BulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(BloodParticleSystem, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        }
        if (collision.gameObject.tag == "Environment")
        {
            Instantiate(HitParticleSystem, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(PlayerBloodParticleSystem, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        }
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<PlayerHealthControl>() != null)
        { 
            collision.gameObject.GetComponent<PlayerHealthControl>().CurrentHP -= currentWeapon.Damage;
            collision.gameObject.GetComponent<PlayerHealthControl>().UpdateHp();
        }
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerHealthControl>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealthControl>().CurrentHP -= currentWeapon.Damage;
            collision.gameObject.GetComponent<PlayerHealthControl>().UpdateHp();
        }

        Destroy(this.gameObject);
    }

    //{
    //    if (collision.gameObject.tag == "Environment")
    //    {
    //        collision.gameObject.GetComponent<HealthControl>().CurrentHP -= currentWeapon.Damage;
    //        collision.gameObject.GetComponent<HealthControl>().UpdateHp();
    //    }
    //    Instantiate(HitParticleSystem, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
    //    Destroy(this.gameObject);
    //}
}
