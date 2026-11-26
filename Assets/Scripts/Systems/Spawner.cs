using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float cooldownSpawn = 5f;
    [SerializeField] private float distanceRandom = 1.5f;
    [SerializeField] float distanceCheck = 0.5f;
    [SerializeField] int maxTry = 10;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldownSpawn);
            TrySpawn();
        }
    }

    void TrySpawn()
    {
        for (int i = 0; i < maxTry; i++)
        {
            Vector2 offset = Random.insideUnitCircle * distanceRandom;
            Vector2 freePosition = (Vector2)transform.position + offset;
            Collider2D[] choques = Physics2D.OverlapCircleAll(freePosition, distanceCheck);
            bool ocupado = false;
            foreach (Collider2D collider in choques)
            {
                if (!collider.isTrigger)
                {
                    ocupado = true;
                    break;
                }
            }
            if (!ocupado)
            {
                Instantiate(enemyPrefab, freePosition, Quaternion.identity);
                return;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceRandom);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceCheck);
    }
}