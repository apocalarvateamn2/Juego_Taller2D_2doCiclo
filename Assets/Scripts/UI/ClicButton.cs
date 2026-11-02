using UnityEngine;
using UnityEngine.SceneManagement;

public class ClicButton : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Nivel 01 test01");
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
