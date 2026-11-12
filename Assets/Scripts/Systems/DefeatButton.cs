using UnityEngine;

public class DefeatButton : MonoBehaviour
{
    public void OnReplayButtonClicked()
    {
        if (CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.FadeToLastSavedScene();
        }
    }
}
