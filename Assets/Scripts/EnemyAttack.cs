using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool CanAttack = false;

    private bool Attacking = false;

    private float AttackTimer = 0;
    private float AttackCd = 3f;

    private Animator anim;

    private void Start()
    {
        InvokeRepeating("Attack", 0.1f, 3f);
    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Attack()
    {
        if (!Attacking && CanAttack)
        {
            Attacking = true;
            AttackTimer = AttackCd;

            return;
        }
        if (Attacking)
        {
            Attacking = false;
        }
    }

    private void Update()
    {
        anim.SetBool("IsAttacking", Attacking);
    }

    public void HeroOnRange(bool onRange)
    {
        CanAttack = onRange;
    }
}
