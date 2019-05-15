using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{

    public GameController gm;

    private float health = 100;
    public int experienceContained = 70;

    public CircleCollider2D foot;

    public Animator animator;
    public Rigidbody2D rb;

    private bool sentExperience = false;

    private void Update()
    {
        if (health <= 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;
            Destroy(foot);
            animator.SetBool("IsDying", true);
            if (!sentExperience)
                SendExperience();
        }
    }

    private void SendExperience()
    {
        gm.ShareExperience(experienceContained);
        sentExperience = true;
        Debug.Log("Shared experience : " + experienceContained);
    }

    public void Damage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log("Skeleton current health: " + health);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerObject player = collision.collider.GetComponent<PlayerObject>();
        if (player != null)
        {
            player.Damaged(15);
        }
    }
}
