using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{

    public GameObject skeleton;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("HeroAttack"))
        {
            Destroy(skeleton);
        }
    }
}
