using UnityEngine;

public class Buttons : MonoBehaviour
{
    private int objectsOnButton = 0;
    public bool isOnButton => objectsOnButton > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectsOnButton++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsOnButton--;

        if (objectsOnButton <= 0) objectsOnButton = 0;
    }
}
