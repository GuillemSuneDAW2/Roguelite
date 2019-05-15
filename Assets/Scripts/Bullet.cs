using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    public GameObject impactEffect;
    private GameObject instantiatedObject;

    private PlayerObject target;
    private Vector2 moveDirection;

    private bool blocked = false;

    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerObject>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerObject player = collision.GetComponent<PlayerObject>();
        PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();

        if (collision.name.Equals("AttackTrigger"))
        {
            blocked = true;
            Destroy(gameObject);
        }

        if (!blocked && player != null)
        {
            instantiatedObject = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            player.Damaged(25f);
            Destroy(instantiatedObject, .5f);
            Destroy(gameObject);
        }
    }
}
