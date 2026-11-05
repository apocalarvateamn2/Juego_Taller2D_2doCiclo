using UnityEngine;

public class BossDetection : MonoBehaviour
{
    private BossBehaviour boss;

    private void Awake()
    {
        boss = GetComponentInParent<BossBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.StartBossCombat();
        }
    }
}
