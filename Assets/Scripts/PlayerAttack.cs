using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool Attacking = false;

    private float AttackTimer = 0;
    private float AttackCd = 0.6f;

    public Collider2D AttackTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        AttackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("f") && !Attacking)
        {
            Attacking = true;
            AttackTimer = AttackCd;

            AttackTrigger.enabled = true;
        }

        if (Attacking)
        {
            if (AttackTimer > 0)
            {
                AttackTimer -= Time.deltaTime;
            }
            else
            {
                Attacking = false;
                AttackTrigger.enabled = false;
            }
        }

        anim.SetBool("IsAttacking", Attacking);
    }
}
