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

<<<<<<< HEAD
        Restart();
=======
        transform.position = positionCheckpoint;
        currentHealth = maxHealth;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = true;
        }
        gameObject.GetComponent<Movement>().UnFreezePlayer();
        LightDetection[] allLights = FindObjectsByType<LightDetection>(FindObjectsSortMode.None);
        foreach (LightDetection lightDet in allLights)
        {
            lightDet.ResetLight();
        }
>>>>>>> 0800c981fccce0591bd37aeb43ea6c065131698c
    }
    
    private void Restart()
    {
        SceneManager.LoadScene("Defeat");
    }
}
