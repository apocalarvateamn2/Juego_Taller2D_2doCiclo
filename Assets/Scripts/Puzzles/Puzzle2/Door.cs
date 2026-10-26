using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorBehaviour doorBh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorBh.OpenPermanently();
        }
    }
}
