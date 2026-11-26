using UnityEngine;

public class EnemyStopLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out EnemyMovement enemyMove))
            {
                enemyMove.FreezeAll();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out EnemyMovement enemyMove))
            {
                enemyMove.UnFrezzeAll();
            }
        }
    }
}
