using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] private float speed;

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
        Vector2 direction = transform.position - player.position;

        if(direction.magnitude < 6.5 && !inLight)
        {
            Vector2 toplayer = (player.position - transform.position).normalized;
            movement = new Vector2(toplayer.x, toplayer.y);
        }
        else movement = Vector2.zero;
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
}
