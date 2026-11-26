using UnityEngine;

public class TriggerAppear : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    [SerializeField] GameObject objeto2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objeto.SetActive(true);
        objeto2.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
