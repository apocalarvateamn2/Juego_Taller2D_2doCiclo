using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Buttons[] requiredButtons;
    [SerializeField] private GameObject door;

    
    private void Update()
    {
        door.SetActive(!AllButtons());
    }
    private bool AllButtons()
    {
        if (requiredButtons.Length == 0) return false;

        foreach (Buttons button in requiredButtons)
        {
            if (button == null || !button.isOnButton) return false;
        }

        return true;
    }
}
