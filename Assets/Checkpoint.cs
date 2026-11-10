using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Checkpoint : MonoBehaviour
{
    public Light2D checkpointLight;
    private void Start()
    {
        checkpointLight.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            stats.NewCheckpoint(transform.position);
            checkpointLight.enabled = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}