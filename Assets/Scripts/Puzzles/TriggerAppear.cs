using UnityEngine;

public class TriggerAppear : MonoBehaviour
{
    public GameObject objeto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objeto.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
