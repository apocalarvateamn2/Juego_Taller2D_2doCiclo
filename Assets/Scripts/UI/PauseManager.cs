using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;

    public void PauseGame()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}