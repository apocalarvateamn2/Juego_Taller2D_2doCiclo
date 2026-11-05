using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossEffects : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField] private float warningTime;
    [SerializeField] private float stunTime;

    private Transform hand;
    private Light2D zone;

    private void Awake()
    {
        hand = transform.Find("MotherHand");

        zone = transform.Find("Zone").GetComponent<Light2D>();
    }

    public IEnumerator Warning(Vector3 hitSpot)
    {
        zone.transform.position = hitSpot;
        zone.enabled = true;

        zone.color = new Color(1f, 0.6f, 0f, 0.4f);

        float t = 0;

        while (t  < warningTime)
        {
            ChangeWarningColor(t);

            t += Time.deltaTime;

            yield return null;
        }

        zone.color = Color.white;
    }

    private void ChangeWarningColor(float t)
    {
        float bright = Mathf.PingPong(t * 3f, 1f);

        zone.color = new Color(1f, 0f, 0f, 0.3f + bright * 0.5f);
    }

    public IEnumerator Stun()
    {
        SpriteRenderer sr = hand.GetComponent<SpriteRenderer>();

        if (sr == null) yield break;

        Color original = sr.color;

        float t = 0;

        while (t < stunTime)
        {
            sr.color = (t % 0.5f < 0.25f) ? original : Color.red;

            t += Time.deltaTime;

            yield return null;
        }

        sr.color = original;
    }
}
