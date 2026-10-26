using Unity.Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineCamera cam;

    [Header("Zoom")]
    [SerializeField] private float normalSize;
    [SerializeField] private float zoomSpeed;

    private float targetSize;

    private void Start()
    {
        targetSize = normalSize;
    }

    private void Update()
    {
        float currentSize = cam.Lens.OrthographicSize;

        currentSize = Mathf.Lerp(
            currentSize, targetSize, Time.deltaTime * zoomSpeed
            );

        cam.Lens.OrthographicSize = currentSize;
    }

    public void SetZoom(float newSize)
    {
        targetSize = newSize;
    }

    public void ResetZoom()
    {
        targetSize = normalSize;
    }
}
