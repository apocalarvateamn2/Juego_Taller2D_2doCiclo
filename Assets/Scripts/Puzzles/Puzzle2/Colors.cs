using UnityEngine;

public class Colors : MonoBehaviour
{
    public EnemyColor.EmyColor rightColor;
    public static int contador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement enemy = collision.GetComponent<EnemyMovement>();

        if(enemy != null)
        {
            if(enemy.color == rightColor)
            {
                enemy.rb.constraints = RigidbodyConstraints2D.FreezeAll;
                contador++;
            }
        }
    }
}
