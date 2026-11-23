using UnityEngine;

public class TutorIMG : MonoBehaviour
{
    [SerializeField] private FlashLight playerFlashLight;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerFlashLight == null) return;
        spriteRenderer.enabled = !playerFlashLight.IsOn;
    }
}