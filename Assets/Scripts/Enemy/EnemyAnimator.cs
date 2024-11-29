using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator enemyAnimator;

    public int isWalkingKey;
    public int isRunningKey;
    public int isAttactKey;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        isWalkingKey = Animator.StringToHash("IsWalking");
        isRunningKey = Animator.StringToHash("IsRunning");
        isAttactKey = Animator.StringToHash("IsAttack");
    }

    public void SetWalkAnimation(bool isWalking)
    {
        enemyAnimator.SetBool(isWalkingKey, isWalking);
    }

    public void SetRunAnimation(bool isRunning)
    {
        enemyAnimator.SetBool(isRunningKey, isRunning);
    }

    public void SetAttackAnimation()
    {
        enemyAnimator.SetTrigger(isAttactKey);
    }
}
