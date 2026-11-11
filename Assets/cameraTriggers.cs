using Unity.Cinemachine;
using UnityEngine;

public class cameraTriggers : MonoBehaviour
{
    public CinemachineCamera cameraWoman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraWoman.Priority.Value = 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraWoman.Priority.Value = -1;
        }
    }
}
