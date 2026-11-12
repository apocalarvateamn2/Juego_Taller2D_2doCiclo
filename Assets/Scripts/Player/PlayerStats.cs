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

    private void Start()
    {
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
        currentHealth -= damage;
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
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

    
    private void Restart()
    {
        SceneManager.LoadScene("Defeat");
    }
}
