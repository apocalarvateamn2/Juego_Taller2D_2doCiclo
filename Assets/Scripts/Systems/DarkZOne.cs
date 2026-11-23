using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarkZone : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private float darkIntensity = 0.05f;
    [SerializeField] private float normalIntensity = 1f;
    [SerializeField] private float transitionSpeed = 1f;

    private float targetIntensity;

    private void Start()
    {
        targetIntensity = globalLight.intensity;
    }

    private void Update()
    {
        globalLight.intensity = Mathf.MoveTowards(
            globalLight.intensity, targetIntensity, transitionSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            targetIntensity = darkIntensity;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            targetIntensity = normalIntensity;
    }
}