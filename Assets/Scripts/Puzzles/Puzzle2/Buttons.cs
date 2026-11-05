using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private bool requiresColor;
    [SerializeField] private EnemyColor.EmyColor requiredColor;

    [HideInInspector] public bool isOnButton => objectsOnButton > 0;
    [HideInInspector] public bool isActivated;
    private int objectsOnButton = 0;
    
    private bool CanActivate(Collider2D collision)
    {
        if (requiresColor)
        {
            if(!collision.CompareTag("Enemy")) return false;

            if (collision.TryGetComponent(out EnemyMovement enemy))
                return enemy.color == requiredColor;

            return false;
        }

        return collision.CompareTag("Enemy") || collision.CompareTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!CanActivate(collision)) return;

        objectsOnButton++;
        isActivated = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CanActivate(collision)) return;

        objectsOnButton--;
        objectsOnButton = Mathf.Max(0, objectsOnButton);

        if (objectsOnButton == 0)
            isActivated = false;
    }
}
