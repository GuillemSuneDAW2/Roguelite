using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilRagnarosController : MonoBehaviour
{

    private float health = 300;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void StartShooting()
    {
        InvokeRepeating("Shoot", 2, 2);
    }

    public void Damage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log("Ragnaros current health: " + health);
        }
        if (health <= 0)
        {
            animator.Play("LilRagDeath");
            Destroy(gameObject, 1f);
        }
    }

    void Shoot()
    {
        if (health > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
