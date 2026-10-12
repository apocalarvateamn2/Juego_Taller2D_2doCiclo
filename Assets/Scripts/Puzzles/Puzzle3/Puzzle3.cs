using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Puzzle3 : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] private TextMeshProUGUI enemies;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI cd;
    [SerializeField] private GameObject puzzleUI;

    [Header ("Timers")]
    [SerializeField] private float timerInZone = 3;
    [SerializeField] private float timerCd = 5;
    [SerializeField] private float increaseTimer = 1.5f;

    [Header ("Puzzle")]
    [SerializeField] private int requiredEnemies = 5;
    [SerializeField] private Light2D zone;
    [SerializeField] private GameObject door;

    private float initialTimerCd;
    private bool isInside = false;
    private bool inCd = false;
    private Collider2D enemy;

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
        requiredEnemies--;
        Destroy(enemy.gameObject);

        isInside = false;
        inCd = true;
        timerCd = initialTimerCd;

        zone.color = Color.red;

        if (requiredEnemies == 0)
        {
            Destroy(door);
            puzzleUI.SetActive(false);
        }


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
            zone.color = Color.yellow;
            enemy = collision;
            isInside = true;
            timerInZone = 5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isInside)
        {
            isInside = false;
            timerInZone = 5f;
            zone.color = Color.green;
        }
    }

    private void FormatText(float seconds, TextMeshProUGUI text)
    {
        int minutes = (int)seconds / 60;
        int second = (int) seconds % 60;

        string format = "{00:00}:{1:00}";
        text.SetText(string.Format(format, minutes, second));
    }

    private void UpdateText()
    {
        enemies.text = requiredEnemies.ToString();
        if (inCd)
        {
            timer.text = "";
            FormatText(timerCd, cd);
            
        }
        else if (isInside)
        {
            cd.text = "";
            FormatText(timerInZone, timer);
        }
        else
        {
            timer.text = "";
            cd.text = "";
        }
    }
}