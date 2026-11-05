using UnityEngine;

public class PuzzleLabyrinth : MonoBehaviour
{
    public GameObject[] partesLaberinto;
    private int fase = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (fase < partesLaberinto.Length)
            {
                partesLaberinto[fase].SetActive(true);
                fase++;
            }
            Destroy(collision.gameObject);
        }
    }
}