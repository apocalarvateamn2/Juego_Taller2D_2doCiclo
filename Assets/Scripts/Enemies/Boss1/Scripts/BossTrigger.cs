using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject bossSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bossSprite.SetActive(true);
            Destroy(gameObject);
        }
    }
}