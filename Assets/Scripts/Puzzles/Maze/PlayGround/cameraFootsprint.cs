using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Rendering.Universal;
public class cameraFootsprint : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private CinemachineCamera camaraPequeña;
    [SerializeField] private Light2D luzGlobal;

    [Header ("Camera Settings")]
    [SerializeField] private float intensidadNormal = 1f;
    [SerializeField] private float intensidadOscura = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camaraPequeña.Priority.Value = 15;
            luzGlobal.intensity = intensidadOscura;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camaraPequeña.Priority.Value = 0;
            luzGlobal.intensity = intensidadNormal;
        }
    }
}