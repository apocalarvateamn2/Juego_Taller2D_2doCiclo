using UnityEngine;

public class WolfShoot : MonoBehaviour
{
    public enum ShootDirection { Up, Down, Left, Right }

    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("Shooting")]
    [SerializeField] private ShootDirection shootDirection = ShootDirection.Down;
    [SerializeField] private float fireInterval = 0.5f;

    private float nextFireTime;

    private void Update()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireInterval;
        Shoot();
    }

    private void Shoot()
    {
        Vector2 direction = GetDirection();
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, angle));

        if (projectile.TryGetComponent(out Bullet bullet))
            bullet.Initialize(direction);
    }

    private Vector2 GetDirection()
    {
        switch (shootDirection)
        {
            case ShootDirection.Up: return Vector2.up;
            case ShootDirection.Down: return Vector2.down;
            case ShootDirection.Left: return Vector2.left;
            default: return Vector2.right;
        }
    }
}