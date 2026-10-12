using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;
    [SerializeField] private Slider lifebar;

    private void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        lifebar.value = currentHealth;
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
        gameObject.GetComponent<Movement>().rb.constraints = RigidbodyConstraints2D.FreezeAll;
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
