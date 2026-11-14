using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance; //guarda referencia global 

    private Vector2 checkpointPosition;
    private string checkpointScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void SaveCheckPoint(Vector2 position)
    {
        checkpointPosition = position;

        checkpointScene = SceneManager.GetActiveScene().name;
    }

    public Vector2 GetSpawnPosition(Vector2 initialPosition)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (checkpointScene == currentScene)
            return checkpointPosition;

        return initialPosition;
    }

    public void FadeToLastSavedScene()
    {
        string scene = SceneManager.GetActiveScene().name;

        if(Fade.Instance != null)
            Fade.Instance.FadeToScene(scene);
        else
            SceneManager.LoadScene(scene);
    }
}