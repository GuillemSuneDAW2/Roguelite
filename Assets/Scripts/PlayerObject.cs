using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{
    public float health = 100f;
    public float damage;
    public int level = 1;
    public int experience = 0;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;

    public GameObject gm;

    public Animator animator;

    public PlayerMovement pm;

    public Transform particlesHit;
    public Transform particlesLevelUp;

    private AudioSource audio;
    public AudioClip damagedAudio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void Damaged(float damage)
    {
        if ((health <= 0) || ((health - damage) <= 0))
        {
            pm.runSpeed = 0;
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
        audio.PlayOneShot(damagedAudio);
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

    public void GainExperience(int gainedExperience)
    {
        Debug.Log("Player recieved " + gainedExperience + " experience");
        experience += gainedExperience;
        if (experience >= 100)
        {
            level++;
            experience -= 100;
            experienceBar.SetSize(0f);
            damage += 10;
            Instantiate(particlesLevelUp, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            experienceBar.SetSize((float)experience / 100);
        }
    }
}
