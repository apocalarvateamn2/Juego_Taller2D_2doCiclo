using UnityEngine;

public class PuzzleLabyrinth : MonoBehaviour
{
    [SerializeField] GameObject[] partesLaberinto;
    [SerializeField] GameObject guide;
    private int fase = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (fase < partesLaberinto.Length)
            {
                partesLaberinto[fase].SetActive(true);
                fase++;

                if (fase == 1)
                    guide.SetActive(false);
            }
            Destroy(collision.gameObject);
        }
    }
}