using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagnarosHitbox : MonoBehaviour
{
    public LilRagnarosController ragnaros;
    public GameObject player;

    private float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("HeroAttack"))
        {
            damage = player.GetComponent<PlayerObject>().damage;

            ragnaros.SendMessage("Damage", damage);
        }
    }
}
