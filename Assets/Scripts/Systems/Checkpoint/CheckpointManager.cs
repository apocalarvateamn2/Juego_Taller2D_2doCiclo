using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance; //guarda referencia global 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            ResetCheckpoint();
        }
        else
            Destroy(gameObject);
    }

    public void SaveCheckPoint(Vector2 position)
    {
        PlayerPrefs.SetFloat("CheckpointX", position.x);
        PlayerPrefs.SetFloat("CheckpointY", position.y);

        string currentSceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene", currentSceneName);

        PlayerPrefs.Save();
    }

    public Vector2 GetSpawnPosition(Vector2 position)
    {
        if (PlayerPrefs.HasKey("CheckpointX"))
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            return new Vector2(x, y);
        }

        return position;
    }

    private string GetLastScene(string scene)
    {
        return PlayerPrefs.GetString("LastScene", scene);
    }

    public void FadeToLastSavedScene()
    {
        string sceneToRetry = GetLastScene("Nivel 01 test 01");

        if (Fade.Instance != null)
        {
            Fade.Instance.FadeToScene(sceneToRetry);
        }
        else
        {
            SceneManager.LoadScene(sceneToRetry);
        }
    }

    private void ResetCheckpoint()
    {
        PlayerPrefs.DeleteKey("CheckpointX");
        PlayerPrefs.DeleteKey("CheckpointY");
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.Save();
    }
}