using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    public GameObject panelPausa;

    public void PauseGame()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}