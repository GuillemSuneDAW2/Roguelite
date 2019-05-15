using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioSource swingSound;

    private bool Attacking = false;

    private float AttackTimer = 0;
    private float AttackCd = 0.33f;

    public Collider2D AttackTrigger;

    private Animator anim;

    private bool IsJumping = false;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        AttackTrigger.enabled = false;
    }

    void Update()
    {
        IsJumping = anim.GetBool("IsJumping");
        if (Input.GetKeyDown("f") && !Attacking && !IsJumping)
        {
            Attacking = true;
            AttackTimer = AttackCd;

            AttackTrigger.enabled = true;

            swingSound.Play();
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
