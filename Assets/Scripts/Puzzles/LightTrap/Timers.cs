using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timers : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI enemies;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI cd;
    [SerializeField] private GameObject puzzleUI;

    public void UpdateEnemies(int amount)
    {
        enemies.text = amount.ToString();
    }

    public void UpdateTimer(float seconds, bool isCooldown)
    {
        if (isCooldown)
        {
            timer.text = "";
            cd.text = FormatText(seconds);
        }
        else
        {
            cd.text = "";
            timer.text = FormatText(seconds);
        }
    }

    public void ClearTimer()
    {
        timer.text = "";
        cd.text = "";
    }

    public void HideUI()
    {
        puzzleUI.SetActive(false);
    }

    private string FormatText(float seconds)
    {
        int minutes = (int)seconds / 60;
        int second = (int)seconds % 60;

        return string.Format("{0:00}:{1:00}", minutes, second);
    }

}
