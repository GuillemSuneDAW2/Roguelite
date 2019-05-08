using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{

    private float health = 100;

    private float dyingTimer = 1.02f;

    public CircleCollider2D foot;

    public Animator animator;
    public Rigidbody2D rb;

    private void Update()
    {
        if (health <= 0)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            Destroy(foot);
            animator.SetBool("IsDying", true);
        }
    }

    public void Damage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log("Skeleton current health: " + health);
        }
    }
}
