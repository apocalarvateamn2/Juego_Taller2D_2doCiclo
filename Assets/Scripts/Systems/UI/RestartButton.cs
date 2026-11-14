using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnReplayButtonClicked()
    {
        CheckpointManager.Instance.FadeToLastSavedScene();
    }

}
