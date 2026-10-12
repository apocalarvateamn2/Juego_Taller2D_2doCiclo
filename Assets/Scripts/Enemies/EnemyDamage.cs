using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerSt = collision.gameObject.GetComponent<PlayerStats>();

            if(playerSt != null)
            {
                playerSt.HealthLoss(40f);
            }
        }
    }
}
