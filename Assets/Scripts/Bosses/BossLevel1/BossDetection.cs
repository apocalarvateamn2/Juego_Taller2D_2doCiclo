using UnityEngine;

public class BossDetection : MonoBehaviour
{
    private CameraBossCinematic cinematicController;

    private void Awake()
    {
        cinematicController = GetComponentInParent<CameraBossCinematic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (cinematicController != null)
                cinematicController.TriggerCinematic();
        }

        gameObject.SetActive(false);
    }
}
