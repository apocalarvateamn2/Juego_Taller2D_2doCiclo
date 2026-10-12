using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.TryGetComponent(out PlayerStats playerSt)) 
            {
                playerSt.HealthLoss(40f);
            }
        }
    }
}
