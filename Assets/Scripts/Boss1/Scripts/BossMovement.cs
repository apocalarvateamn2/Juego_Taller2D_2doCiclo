using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;
    public FlashLight flashLight;
    public float speed = 3f;
    public float crecimiento;
    public float tamañoMaximo;
    public GameObject boomSangre;

    private void Update()
    {
        if (flashLight.IsOn)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
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
        Destroy(gameObject);
    }
}