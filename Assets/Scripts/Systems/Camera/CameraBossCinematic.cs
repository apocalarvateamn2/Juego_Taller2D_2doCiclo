using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class CameraBossCinematic : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera cinematicCamera;

    [Header("Spot")]
    [SerializeField] private Transform centerZoneTarget;

    private BossBehaviour bossBehaviour;
    private BossMovement bossMovement;

    private BossEffects bossEffects;

    private Movement move;

    private bool triggered = false;

    private void Awake()
    {
        bossBehaviour = GetComponent<BossBehaviour>();
        bossMovement = GetComponent<BossMovement>();
        bossEffects = GetComponent<BossEffects>();
        move = FindAnyObjectByType<Movement>();
    }

    public void TriggerCinematic()
    {
        if (!triggered)
        {
            triggered = true;
            StartCoroutine(PlayCinemachineSequence());
        }
    }

    private IEnumerator PlayCinemachineSequence()
    {
        move.FreezePlayer();

        if (cinematicCamera != null && playerCamera != null)
            cinematicCamera.Priority = 20;
          
        yield return new WaitForSeconds(0.5f);

        if(bossEffects != null && centerZoneTarget != null)
            yield return bossEffects.Warning(centerZoneTarget.position);

        if (bossMovement != null && centerZoneTarget != null)
            yield return bossMovement.FallAtPositionCinematic(centerZoneTarget.position, 40f);

        yield return new WaitForSeconds(0.4f);

        if (bossMovement != null)
            yield return bossMovement.ReturnHand();

        if (cinematicCamera != null && playerCamera != null)
            cinematicCamera.Priority = 0;
            
        move.UnFreezePlayer();

        yield return new WaitForSeconds(0.5f);

        if (bossBehaviour != null)
            bossBehaviour.StartBossCombat();
    }
}
