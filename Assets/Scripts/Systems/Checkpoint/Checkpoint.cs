using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointLightEffect lightEffect;

    private void Start()
    {
        lightEffect = GetComponentInChildren<CheckpointLightEffect>();

        if (lightEffect != null) 
            lightEffect.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckpointManager.Instance.SaveCheckPoint(transform.position);

            if (lightEffect != null)
                lightEffect.ActivatedEffect();

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
