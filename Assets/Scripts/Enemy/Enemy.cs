using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
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

    [Header("Enemy HP")]
    public float EnemyCurrentHP;
    public float EnemyOriginalHP = 15;
    public float GotAttackHP;

    [Header("Vision")]
    float visionDistance = 20f;
    float visionAngel = 90;
    private bool isLast = false;

    private Vector3 last;
    public Vector3 Last
    {
        get { return last; }
        set 
        { 
            if(value != last) 
            {
                last = value;
                isLast = false;
            }
        }
    }

    public bool findPlayer = false;
    public bool IsHit = false;

    [Header("Fire")]
    public GameObject BullectPrefab;
    public Transform _enemySR;
    public Vector3 bulletRotation;
    public Vector3 hitPosition;
    public Ray WeaponRay;

    void Start()
    {
        animatorCtrl = GetComponent<EnemyAnimator>();
        EnemyCurrentHP = EnemyOriginalHP;
    }
    void Update()
    {
       if (findPlayer || IsHit)
        {
            Chase();
        }
       else 
        {
            Patrol();
        }

        Vision();

        if(Last != null)
        {
            if ((transform.position - last).magnitude <= 1)
            {
                isLast = true;
            }
        }

        if (EnemyCurrentHP <= 0)
        {
            Destroy(Enumy.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Chase();
            Attack();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Chase();
            EnemyCurrentHP--;
            Debug.Log("-hp");

        }
        //if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerHealthControl>() != null)
        //{
        //    //collision.gameObject.GetComponent<PlayerHealthControl>().CurrentHP--;
        //    GotAttackHP = collision.gameObject.GetComponent<PlayerHealthControl>().CurrentHP - 5;
        //    collision.gameObject.GetComponent<PlayerHealthControl>().CurrentHP = GotAttackHP;
        //    collision.gameObject.GetComponent<PlayerHealthControl>().UpdateHp();
        //}
    }
    //private void OnCollisonStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerHealthControl>() != null)
    //    {
    //        //Debug.Log("11111");
    //        collision.gameObject.GetComponent<PlayerHealthControl>().CurrentHP--;
    //        collision.gameObject.GetComponent<PlayerHealthControl>().UpdateHp();
    //    }
    //}

    //public void HpDown(float percentage)
    //{
    //    EnemyHPBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, EnemyImageOGSize * percentage);
    //}

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
                Debug.Log(hit.collider.name);
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.transform.CompareTag("Player"))
                {
                    Last = hit.transform.position;
                    Debug.DrawLine(ray.origin, hit.point, Color.green);
                    findPlayer = true;
                }
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

    private void Patrol()
    {
        if (GetComponent<NavMeshAgent>().remainingDistance < 2f)
        {
            GetComponent<NavMeshAgent>().speed = 1;
            index++;
            if (index > waypoints.Length - 1)
                index = 0;

            GetComponent<NavMeshAgent>().destination = waypoints[index].position;
            animatorCtrl.SetWalkAnimation(true);
        }

    }
    private void Chase()
    {
        animatorCtrl.SetWalkAnimation(false);
        animatorCtrl.SetRunAnimation(true);
        GetComponent<NavMeshAgent>().speed = 5;
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
        EnemyEyePos.LookAt(playerPos);
    }

    private void Attack()
    {
        animatorCtrl.SetAttackAnimation();
        //GetComponent<NavMeshAgent>().destination = Player.transform.position;

        //if(!IsHit)
        //{
        //    StartCoroutine(generaterBullet());
        //}
        //IsHit = true;
    }

    //IEnumerator generaterBullet()
    //{
    //    int i = 0;
    //    while(i < 5)
    //    {
    //        Vector3 targertDirection = playerPos.position - transform.position;
    //        Instantiate(BullectPrefab, _enemySR.position, Quaternion.LookRotation(targertDirection, Vector3.up));
    //        i++;
    //        Debug.Log("Bullet generate count: " + i);
    //        if (i == 5)
    //            IsHit = false;
    //        yield return new WaitForSeconds(1);
    //    }
    //}

}


