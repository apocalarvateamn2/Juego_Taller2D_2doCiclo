using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [SerializeField] private CameraZoom cameraZoom;
    [SerializeField] private float zoneSize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraZoom.SetZoom(zoneSize);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraZoom.ResetZoom();
        }
    }
}
