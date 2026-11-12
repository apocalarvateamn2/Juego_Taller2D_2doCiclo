using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.TryGetComponent(out PlayerStats playerSt)) 
            {
                playerSt.HealthLoss(damage);
            }
        }
    }
}
