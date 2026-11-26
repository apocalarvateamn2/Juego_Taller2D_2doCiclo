using UnityEngine;

public class BossDetection : MonoBehaviour
{
    [SerializeField] private GameObject spawns;
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
            {
                cinematicController.TriggerCinematic();
                spawns.SetActive(true);
            }
                
        }

        gameObject.SetActive(false);
    }
}
