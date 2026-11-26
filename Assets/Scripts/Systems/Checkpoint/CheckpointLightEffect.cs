using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CheckpointLightEffect : MonoBehaviour
{
    private Light2D checkpointLight;

    private float timer;

    private void Awake()
    {
       checkpointLight = GetComponentInChildren<Light2D>();
       checkpointLight.enabled = false;
    }

    public void ActivatedEffect()
    {
        checkpointLight.enabled = true;
        enabled = true;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        ChangeCheckpointColor(timer);
    }

    public void ChangeCheckpointColor(float t)
    {
        float bright = Mathf.PingPong(t * 1.5f, 1f);

        checkpointLight.color = new Color(0.56f, 0.14f, 0f, 1f + bright * 0.2f);
    }
}
