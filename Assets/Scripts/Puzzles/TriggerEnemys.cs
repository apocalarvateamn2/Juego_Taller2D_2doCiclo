using UnityEngine;

public class TriggerEnemys : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
