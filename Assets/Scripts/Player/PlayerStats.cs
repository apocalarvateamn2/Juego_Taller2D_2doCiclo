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

    IEnumerator Die()
    {
        gameObject.GetComponent<Movement>().FreezePlayer();
        yield return new WaitForSeconds(0.5f);
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = false;
        }
        Invoke("Restart", 1f);
    }
    
    private void Restart()
    {
        SceneManager.LoadScene("New Scene");
    }
}
