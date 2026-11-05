using System.Collections;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private Vector2 hitBoxSize = new Vector2(3f, 2f);

    [Header("Damage")]
    [SerializeField] private float freezeTime;

    private Transform hand;

    private Movement move;
    private PlayerStats st;

    public int enemiesCrashed = 0;

    private void Awake()
    {
        hand = transform.Find("MotherHand");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        move = player.GetComponent<Movement>();
        st = player.GetComponent<PlayerStats>();
    }

    public bool Crash()
    {
        bool enemyHit = false;

        Collider2D[] characters = Physics2D.OverlapBoxAll(hand.position, hitBoxSize, 0f);

        foreach (Collider2D character in characters)
        {
            if (character.CompareTag("Enemy"))
            {
                enemyHit = true;
                enemiesCrashed++;

                Destroy(character.gameObject);
            }
            else if (character.CompareTag("Player"))
            {
                st.HealthLoss(40f);

                StartCoroutine(PlayerCrash());
            }
        }

        return enemyHit;
    }

    private IEnumerator PlayerCrash()
    {
        move.FreezePlayer();
        yield return new WaitForSeconds(freezeTime);
        move.UnFreezePlayer();
    }

    private void OnDrawGizmos()
    {
        if (hand == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hand.position, hitBoxSize);
    }
}
