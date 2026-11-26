using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private bool requiresColor;
    [SerializeField] private EnemyColor.EmyColor requiredColor;
    [SerializeField] private GameObject bottonPressed;
    [SerializeField] private Transform centerPoint;
    [HideInInspector] public bool isActivated;
    private int objectsOnButton = 0;

    public bool isOnButton => objectsOnButton > 0 || isActivated;
  
    private float moveSpeed;

    private bool CanActivate(Collider2D collision)
    {
        if (requiresColor)
        {
            if (!collision.CompareTag("Enemy")) return false;

            if (collision.TryGetComponent(out EnemyMovement enemy))
                return enemy.color == requiredColor;

            return false;
        }

        return collision.CompareTag("Enemy") || collision.CompareTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!CanActivate(collision)) return;

        if (collision.CompareTag("Enemy"))
        {
            if (isActivated) return;

            if (collision.TryGetComponent(out EnemyMovement enemy))
            {
                if (centerPoint != null)
                {
                    Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.linearVelocity = Vector2.zero;
                        rb.position = centerPoint.position;
                    }
                }

                enemy.FreezeAll();
            }

            isActivated = true;
        }

        CountObjects();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        objectsOnButton = Mathf.Max(0, objectsOnButton - 1);

        if(objectsOnButton == 0 && !isActivated)
        {
            if (bottonPressed != null)
                bottonPressed.SetActive(false);
        }
    }

    private void CountObjects()
    {
        objectsOnButton++;

        if (bottonPressed != null)
            bottonPressed.SetActive(true);
    }
}
