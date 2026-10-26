using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Buttons[] requiredButtons;
    [SerializeField] private bool requireRightColors;

    private void Update()
    {
        if (AllButtons())
        {
            door.SetActive(false);
        }
        else door.SetActive(true);
    }

    private bool AllButtons()
    {
        if (requiredButtons.Length == 0) return false;

        foreach (Buttons button in requiredButtons)
        {
            if (button == null || !button.isOnButton) return false;
             
            if (requireRightColors && !button.isActivated) return false;
        }

        return true;
    }
}
