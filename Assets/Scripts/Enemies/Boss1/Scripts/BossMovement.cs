using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private Transform player;
    [SerializeField] private FlashLight flashLight;
    [SerializeField] private GameObject boomSangre;
    [SerializeField] private GameObject bossObject;

    [Header ("Boss Mechanics")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float crecimiento;
    [SerializeField] private float tamañoMaximo;


    private void Update()
    {
        if (flashLight.IsOn)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            transform.localScale += new Vector3(crecimiento, crecimiento, 0f);

            if (transform.localScale.x >= tamañoMaximo)
            {
                Explotar();
            }
        }
    }
    private void Explotar()
    {
        Instantiate(boomSangre, transform.position, Quaternion.identity);
        bossObject.SetActive(false);
        Invoke("Win", 1f);
    }
    private void Win()
    {
        SceneManager.LoadScene("Victory");
    }
}