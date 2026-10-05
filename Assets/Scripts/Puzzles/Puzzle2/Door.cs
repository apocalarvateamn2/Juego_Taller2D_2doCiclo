using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen;
    private void Update()
    {
        if(Colors.contador == 2 && !isOpen)
        {
            isOpen = true;
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Destroy(gameObject);
    }
}
