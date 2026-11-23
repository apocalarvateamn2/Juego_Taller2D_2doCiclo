using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float spawnOffset = 0.5f;

    [Header("Cooldown")]
    [SerializeField] private float cooldown = 2f;

    private float nextAllowedTime;

    private static readonly Vector2[] directions =
    {
        Vector2.up, Vector2.down, Vector2.left, Vector2.right
    };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Light")) return;
        if (Time.time < nextAllowedTime) return;

        nextAllowedTime = Time.time + cooldown;
        Shoot();
    }

    private void Shoot()
    {
        foreach (Vector2 dir in directions)
        {
            Vector3 position = transform.position + (Vector3)(dir * spawnOffset);
            GameObject projectile = Instantiate(projectilePrefab, position, Quaternion.identity);

            if (projectile.TryGetComponent(out Bullet bullet))
                bullet.Initialize(dir);
        }
    }
}
