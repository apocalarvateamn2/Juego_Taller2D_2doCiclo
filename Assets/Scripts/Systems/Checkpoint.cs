using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Check : MonoBehaviour
{
    public Light2D checkpointLight;

    private void Start()
    {
        if (checkpointLight != null) checkpointLight.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckpointManager.Instance.SaveCheckPoint(transform.position);

            if (checkpointLight != null) checkpointLight.enabled = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
