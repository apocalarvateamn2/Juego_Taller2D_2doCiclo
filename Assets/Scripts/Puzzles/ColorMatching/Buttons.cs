using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Buttons : MonoBehaviour
{
    [SerializeField] private bool requiresColor;
    [SerializeField] private EnemyColor.EmyColor requiredColor;
    [SerializeField] private GameObject bottonPressed;

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

        return collision.CompareTag("Enemy");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!CanActivate(collision)) return;

        if (collision.TryGetComponent(out EnemyMovement enemy))
        {
            enemy.FreezeAll();
        }

        if(bottonPressed != null)
        {
            bottonPressed.SetActive(true);
        }
            
        objectsOnButton++;
        isActivated = true;
        
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (!CanActivate(collision)) return;

    //    objectsOnButton--;
    //    objectsOnButton = Mathf.Max(0, objectsOnButton);

    //    if (objectsOnButton == 0)
    //        isActivated = false;
    //}
}
