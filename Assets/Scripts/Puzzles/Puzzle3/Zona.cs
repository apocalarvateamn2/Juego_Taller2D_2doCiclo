using UnityEngine;

public class Zona : MonoBehaviour
{
    public int enemigosNecesarios = 3;

    public float tiempoParaAceptar = 5f;
    public float tiempoEnfriamiento = 3f;

    private float temporizador;
    private bool enemigoDentro;
    private bool enfriamiento;

    void Update()
    {
        if (enemigoDentro && !enfriamiento)
        {
            temporizador -= Time.deltaTime;

            if (temporizador <= 0)
            {
                AceptarEnemigo();
            }
        }

        if (enfriamiento)
        {
            temporizador -= Time.deltaTime;

            if (temporizador <= 0)
            {
                enfriamiento = false;
            }
        }

        if (enemigosNecesarios <= 0)
        {
            CompletarNivel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !enfriamiento)
        {
            enemigoDentro = true;
            temporizador = tiempoParaAceptar;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !enfriamiento)
        {
            enemigoDentro = false;
            temporizador = 0;
        }
    }

    void AceptarEnemigo()
    {
        enemigosNecesarios--;

        enemigoDentro = false;

        enfriamiento = true;
        temporizador = tiempoEnfriamiento;
    }

    void CompletarNivel()
    {
        Debug.Log("¡Nivel completado!");
    }

}
