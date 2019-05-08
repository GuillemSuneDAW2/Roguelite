using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public GameObject test;
    //public SkeletonController skeleton;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("HeroAttack"))
        {
            test.SendMessage("Damage", 25f);
            //skeleton.Damage(25f);
        }
    }
}
