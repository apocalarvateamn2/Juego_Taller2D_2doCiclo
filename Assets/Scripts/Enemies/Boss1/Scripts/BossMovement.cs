using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public Transform player;
    public FlashLight flashLight;
    public float speed = 3f;
    public float crecimiento;
    public float tamañoMaximo;
    public GameObject boomSangre;
    public GameObject bossObject;

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