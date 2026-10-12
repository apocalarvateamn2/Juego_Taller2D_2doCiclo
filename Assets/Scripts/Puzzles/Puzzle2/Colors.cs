using UnityEngine;

public class Colors : MonoBehaviour
{
    [SerializeField] private EnemyColor.EmyColor rightColor;

    public static int counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent(out EnemyMovement enemy))
            {
                if(enemy.color == rightColor)
                {
                    enemy.FreezeAll();
                    counter++;
                }
            }
        }
    }
}
