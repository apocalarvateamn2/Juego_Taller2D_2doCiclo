using UnityEngine;

public class LightSprout : MonoBehaviour
{
    [SerializeField] private GameObject sproutObject;
    [SerializeField] private GameObject treeObject;

    private void Start()
    {
        SetGrown(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
            SetGrown(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
            SetGrown(false);
    }

    private void SetGrown(bool grown)
    {
        sproutObject.SetActive(!grown);
        treeObject.SetActive(grown);
    }
}