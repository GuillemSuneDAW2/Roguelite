using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public GameObject skeleton;
    public GameObject player;

    private float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("HeroAttack"))
        {
            damage = player.GetComponent<PlayerObject>().damage;

            skeleton.SendMessage("Damage", damage);
        }
    }
}
