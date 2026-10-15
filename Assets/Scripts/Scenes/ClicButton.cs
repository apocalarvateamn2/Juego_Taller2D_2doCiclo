using UnityEngine;
using UnityEngine.SceneManagement;

public class ClicButton : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("New Scene");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
