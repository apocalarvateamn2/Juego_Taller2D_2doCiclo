using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float maxDistance = 2f;

    [Header("Damage")]
    [SerializeField] private float damage = 10f;

    [Header("Collision")]
    [SerializeField] private LayerMask blockingLayers;

    private Vector2 direction;
    private Vector2 startPosition;

    public void Initialize(Vector2 newDirection)
    {
        direction = newDirection.normalized;
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsBlocking(collision))
        {
            Destroy(gameObject);
            return;
        }

        if (!collision.CompareTag("Player")) return;

        if (collision.TryGetComponent(out PlayerStats playerStats))
            playerStats.HealthLoss(damage);

        Destroy(gameObject);
    }

    private bool IsBlocking(Collider2D collision)
    {
        return (blockingLayers.value & (1 << collision.gameObject.layer)) != 0;
    }
}
