using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float maxHealth;

    [Header ("UI")]
    [SerializeField] private Image lifebar;

    private float currentHealth;
    private Vector2 positionCheckpoint;

    private void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        positionCheckpoint = transform.position;
    }

    private void Update()
    {
        float targetFill = currentHealth / maxHealth;
        lifebar.fillAmount = Mathf.Lerp(lifebar.fillAmount, targetFill, Time.deltaTime * 5);

    }

    public void HealthLoss (float damage)
    {
        currentHealth -= damage;
        CheckStatus();
    }

    //public void HealthGain (float amount)
    //{
    //    currentHealth += amount;
    //    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    //}

    private void CheckStatus()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }
    public void NewCheckpoint(Vector2 newPosition)
    {
        positionCheckpoint = newPosition;
    }

    IEnumerator Die()
    {
        gameObject.GetComponent<Movement>().FreezePlayer();
        yield return new WaitForSeconds(0.5f);
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = false;
        }
        yield return new WaitForSeconds(0.5f);

        transform.position = positionCheckpoint;
        currentHealth = maxHealth;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = true;
        }
        gameObject.GetComponent<Movement>().UnFreezePlayer();
    }
    
    private void Restart()
    {
        SceneManager.LoadScene("Defeat");
    }
}
