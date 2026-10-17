using UnityEngine;
public class CreditsScroller : MonoBehaviour
{
    [SerializeField] private float speedCredits = 50f;

    void Update()
    {
        transform.Translate(Vector2.up * speedCredits * Time.deltaTime);
    }
}