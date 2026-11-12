using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnReplayButtonClicked()
    {
        if (CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.FadeToLastSavedScene();
        }
    }

}
