using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    [Header("Detection")]
    [SerializeField] private LayerMask obstacleMask;

    public EnemyColor.EmyColor color;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
   
    private bool inLight = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (!inLight && CanSeePlayer())
            movement = (player.position - transform.position).normalized;
        else
            movement = Vector2.zero;
    }

    private bool CanSeePlayer()
    {
        Vector2 toPlayer = player.position - transform.position;

        if (toPlayer.magnitude > distance) return false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayer.normalized,toPlayer.magnitude, obstacleMask);

        return hit.collider == null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            inLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            inLight = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +  movement * speed * Time.deltaTime);
    }

    public void FreezeAll()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnDrawGizmos()
    {
        if(player == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance);

        Vector2 toPlayer = player.position - transform.position;
        if(toPlayer.magnitude <= distance)
        {
            Gizmos.color = CanSeePlayer() ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}
