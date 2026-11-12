using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float maxHealth;

    [Header("Inulverability")]
    [SerializeField] private float invulnerabilityDuration = 1.5f;
    [SerializeField] private float flashInterval = 0.15f;

    [Header ("UI")]
    [SerializeField] private Image lifebar;

    private float currentHealth;
    private bool isInvulnerable = false;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxHealth = 100f;
        currentHealth = maxHealth;
        CheckPoint();
    }

    private void Update()
    {
        float targetFill = currentHealth / maxHealth;
        lifebar.fillAmount = Mathf.Lerp(lifebar.fillAmount, targetFill, Time.deltaTime * 5);
    }

    public void HealthLoss (float damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    private void CheckPoint()
    {
        if(CheckpointManager.Instance != null)
            transform.position = CheckpointManager.Instance.GetSpawnPosition(transform.position);
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

        Restart();
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        Color originalColor = sr.color;

        float elapsed = 0f;

        while (elapsed < invulnerabilityDuration)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(flashInterval / 2f);

            sr.color = originalColor;
            yield return new WaitForSeconds(flashInterval / 2f);

            elapsed += flashInterval;
        }

        sr.color = originalColor;

        isInvulnerable = false;
    }

    
    private void Restart()
    {
        SceneManager.LoadScene("Defeat");
    }
}
