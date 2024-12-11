using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GourdControl : MonoBehaviour
{
    [Header("References")]
    public GameObject Enumy;
    public GameObject Player;
    public NavMeshAgent agent;
    public Transform playerPos;
    public Transform EnemyEyePos;
    public EnemyAnimator animatorCtrl;

    [Header("Patrol")]
    public Transform[] waypoints;
    public int index;


    [Header("Vision")]
    public float visionDistance = 15f;
    public float visionAngel = 120;
    private bool isLast = false;
    private bool doNothing = false;

    [Header("Enemy HP")]
    //public Transform HitParticleSystem;
    public float EnemyCurrentHP;
    public float EnemyOriginalHP = 15;
    public float EnemyAttackedHP;
    public float GotAttackHP;
    public bool isDead = false;
    //public GameObject LiveEnemy;
    public GameObject[] DeadEnemy;


    private Vector3 last;
    public Vector3 Last
    {
        get { return last; }
        set
        {
            if (value != last)
            {
                last = value;
                isLast = false;
            }
        }
    }


    public bool findPlayer = false;



    void Start()
    {
        //animatorCtrl = GetComponent<EnemyAnimator>();
        EnemyCurrentHP = EnemyOriginalHP;
    }

    void Update()
    {
        if (!isDead)
        {
            Vision();
            if (findPlayer)

            {
                Chase();
            }
            else
            {
                Patrol();
            }

            if (Last != null)
            {
                if ((transform.position - last).magnitude <= 3)
                {
                    isLast = true;
                }
            }

        }

    }


    private void Vision()
    {
        float distance = Vector3.Distance(playerPos.position, EnemyEyePos.position);
        Vector3 targertDirection = playerPos.position - EnemyEyePos.position;
        targertDirection.y = 0;
        Vector3 forward = EnemyEyePos.position + transform.forward;
        Vector3 direction = forward - EnemyEyePos.position;
        direction.y = 0;

        float angle = Vector3.Angle(targertDirection, direction);
        if (distance < visionDistance && angle < visionAngel)
        {
            Ray ray = new Ray(EnemyEyePos.position, targertDirection);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.transform.CompareTag("Player"))
                {
                    Last = hit.transform.position;
                    Debug.DrawLine(ray.origin, hit.point, Color.green);
                    findPlayer = true;
                }
                //if (hit.transform.tag == "Wall")
                //{

                //    Debug.DrawLine(ray.origin, hit.point, Color.black);
                //    findPlayer = false;
                //}
                else
                {
                    if (!isLast)
                    {
                        GetComponent<NavMeshAgent>().destination = last;
                    }
                }
            }
        }
        else
        {
            findPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isDead)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Attack");
                //HPDownAudioSource.PlayOneShot(HPDownPClip);
                //EnemyAudioSource.PlayOneShot(EnemyAttackClip);
                Chase();
                Attack();
            }
            if (other.gameObject.CompareTag("Talisman"))
            {
                Debug.Log("GotAttack");
                Chase();
                EnemyCurrentHP--;
            }

            if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<MyHealthControl>() != null)
            {
                Debug.Log("MyHp--");
                other.gameObject.GetComponent<MyHealthControl>().CurrentHP--;
                other.gameObject.GetComponent<MyHealthControl>().UpdateHp();
            }
        }
    }

    private void OnCollisonStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<MyHealthControl>() != null)
        {
            Debug.Log("MyHpDown");
            collision.gameObject.GetComponent<MyHealthControl>().CurrentHP--;
            collision.gameObject.GetComponent<MyHealthControl>().UpdateHp();
        }
    }


    private void Chase()
    {
        //EnemyChaceAudio.SetActive(true);
        //animatorCtrl.SetWalkAnimation(false);
       // animatorCtrl.SetRunAnimation(true);
        GetComponent<NavMeshAgent>().speed = 6;
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
        EnemyEyePos.LookAt(playerPos);
    }


    private void Attack()
    {
        animatorCtrl.SetAttackAnimation();
        GetComponent<NavMeshAgent>().destination = Player.transform.position;

        //if(!IsHit)
        //{
        //    StartCoroutine(generaterBullet());
        //}
        //IsHit = true;
    }


    private void Patrol()
    {
        if (GetComponent<NavMeshAgent>().remainingDistance < 2f)
        {
            GetComponent<NavMeshAgent>().speed = 1;
            index++;
            if (index > waypoints.Length - 1)
                index = 0;

            GetComponent<NavMeshAgent>().destination = waypoints[index].position;
            //animatorCtrl.SetWalkAnimation(true);
           // animatorCtrl.SetRunAnimation(false);
        }

    }




}
