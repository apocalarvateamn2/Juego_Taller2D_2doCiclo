using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
    public float velocidad = 50f;

    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }
}