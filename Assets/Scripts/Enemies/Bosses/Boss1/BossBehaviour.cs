using System.Collections;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [Header("Win Conditions")]
    [SerializeField] private int requieredEnemies = 10;

    private BossMovement movement;
    private BossCombat combat;
    private BossEffects effects;

    private bool combatStarted = false;

    private void Awake()
    {
        movement = GetComponent<BossMovement>();

        combat = GetComponent<BossCombat>();

        effects = GetComponent<BossEffects>();
    }

    private void Start()
    {
        movement.Initialize();
    }

    public void StartBossCombat()
    {
        if (!combatStarted)
        {
            combatStarted = true;
            StartCoroutine(StartCombat());
        }
    }

    private IEnumerator StartCombat()
    {
        while (combat.enemiesCrashed < requieredEnemies)
        {
            yield return movement.Chase();

            yield return effects.Warning(movement.Hitspot);

            yield return movement.Fall();

            bool enemyHit = combat.Crash();

            if (enemyHit)
                yield return effects.Stun();
            else
                yield return movement.WaitOnGround();

            yield return movement.ReturnHand();
        }

        Destroy(gameObject, 0.5f);
    }
}
