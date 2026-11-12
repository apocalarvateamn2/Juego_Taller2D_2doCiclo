using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class LightTrap : MonoBehaviour
{
    [Header ("Timers")]
    [SerializeField] private float timerInZone = 3;
    [SerializeField] private float timerCd = 5;
    [SerializeField] private float increaseTimer = 1.5f;

    [Header("Puzzle")]
    [SerializeField] private int requiredEnemies = 5;
    [SerializeField] private Light2D zone;
    [SerializeField] private GameObject door;

    [Header("RandomArea")]
    [SerializeField] private Vector2 minArea;
    [SerializeField] private Vector2 maxArea;

    [Header("UI")]
    [SerializeField] private Timers timersUI;

    private float initialTimerCd;
    private bool isInside = false;
    private bool inCd = false;
    private List<Collider2D> enemies = new List<Collider2D>(); 

    private void Awake()
    {
        initialTimerCd = timerCd;
    }

    private void Start()
    {
        zone.color = Color.green;
        UpdateText();
    }

    private void Update()
    {
        Zone();
    }

    private void Zone()
    {
        if (isInside && !inCd)
        {
            timerInZone -= Time.deltaTime;

            if(timerInZone <= 0)
            {
                InZone();
            }
        }

        if (inCd)
        {
            timerCd -= Time.deltaTime;

            if( timerCd <= 0)
            {
                InCd();
            }
        }

        UpdateText();
    }

    private void InZone()
    {
        requiredEnemies -= enemies.Count;

        for (int i =  enemies.Count - 1; i >= 0; i--)
        {
            Destroy(enemies[i].gameObject);
        }

        enemies.Clear();

        isInside = false;
        inCd = true;
        timerCd = initialTimerCd;

        zone.color = Color.red;

        MoveLightToRandomPosition();

        EnemyLightLevel2 levelEvents = GetComponent<EnemyLightLevel2>();
        levelEvents.LightNextEvent();

        if (requiredEnemies <= 0)
        {
            requiredEnemies = 0;
            Destroy(door);
            timersUI.HideUI();
            zone.color = Color.green;
        }
    }

    private void MoveLightToRandomPosition()
    {
        float randomX = Random.Range(minArea.x, maxArea.x);
        float randomY = Random.Range(minArea.y, maxArea.y);

        transform.position = new Vector3 (randomX, randomY, transform.position.z);
    }

    private void InCd()
    {
        inCd = false;
        timerInZone = 5;
        initialTimerCd += increaseTimer;

        zone.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !inCd)
        {
            if(!enemies.Contains(collision))
                enemies.Add(collision);

            zone.color = Color.yellow;
            isInside = true;
            timerInZone = 5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision);

            if (enemies.Count == 0 && isInside)
            {
                isInside = false;
                timerInZone = 5f;
                zone.color = Color.green;
            }
        }
    }

    private void UpdateText()
    {
        timersUI.UpdateEnemies(requiredEnemies);

        if (inCd)
            timersUI.UpdateTimer(timerCd, true);
        else if (isInside)
            timersUI.UpdateTimer(timerInZone, false);
        else
            timersUI.ClearTimer();
    }
}