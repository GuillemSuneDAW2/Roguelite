using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{
    public float health = 100f;
    public float damage;

    public HealthBar healthBar;

    public GameObject gm;

    public Animator animator;

    public Transform particlesHit;

    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            Damaged(damage);
        }
    }

    public void Damaged(float damage)
    {
        if ((health <= 0) || ((health - damage) <= 0))
        {
            healthBar.SetSize(0f);
            animator.Play("PlayerDie", 0);
            Invoke("LoadScene", 3);
        }
        else
        {
            health -= damage;
            healthBar.SetSize(health / 100);
            Instantiate(particlesHit, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DieZone")
        {
            animator.Play("PlayerDie", 0);
            Invoke("LoadScene", 3);
        }
        else if (collision.tag == "BridgeCollider")
        {
            gm.SendMessage("DestroyBridge");
        }
    }
}
