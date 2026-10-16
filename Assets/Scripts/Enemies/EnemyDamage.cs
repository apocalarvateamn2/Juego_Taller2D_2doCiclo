using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage; //valor publico para usarlo en cualquier objeto
    private void OnCollisionEnter2D(Collision2D collision)
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
