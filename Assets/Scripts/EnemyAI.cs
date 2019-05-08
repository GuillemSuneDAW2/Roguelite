using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    // Control the animations
    private Animator animator;

    // Bool to rotate the Enemy
    private bool FacingRight = true;

    // What to chase
    public Transform target;
    //private Transform hero;

    // How many times each second we will update our path
    public float updateRate = 2f;

    // Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    // The calculated path
    public Path path;

    // The AI's speed
    private float speed = 0f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool PathIsEnded = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float NextWayPointDistance = 3;

    // The waypoint we are currently moving towards
    private int CurrentWayPoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (target == null)
        {
            Debug.LogError("No player found.");
            return;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            // TODO: Insert a player search here
            yield break;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1 / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Error?:" + p.error);

        if (!p.error)
        {
            path = p;
            CurrentWayPoint = 0;
        }
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (transform.position.x < target.position.x && !FacingRight)
            Flip();
        
        if (transform.position.x > target.position.x && FacingRight)
            Flip();
    }

    void FixedUpdate()
    {
        if (target == null)
            return;

        if (path == null)
            return;

        if (CurrentWayPoint >= path.vectorPath.Count)
        {
            if (PathIsEnded)
                return;

            Debug.Log("End of path reached.");
            PathIsEnded = true;
            return;
        }

        PathIsEnded = false;

        // Direction to the next waypoint
        Vector3 direction = (path.vectorPath[CurrentWayPoint] - transform.position).normalized;
        direction *= speed * Time.fixedDeltaTime;

        // Move the AI
        rb.AddForce(direction, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[CurrentWayPoint]);

        if (dist < NextWayPointDistance)
        {
            CurrentWayPoint++;
            return;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hero"))
        {
            speed = 300f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hero"))
        {
            speed = 0f;
        }
    }
}