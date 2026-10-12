using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Rendering.Universal;
public class cameraNivelHuellas : MonoBehaviour
{
    public CinemachineCamera camaraPequeña;
    public Light2D luzGlobal;

    public float intensidadNormal = 1f;
    public float intensidadOscura = 0.3f;

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