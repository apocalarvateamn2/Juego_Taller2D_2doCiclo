using UnityEngine;

public class DestroyedObjects: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MotherHand"))
            Destroy(gameObject);
    }
}
