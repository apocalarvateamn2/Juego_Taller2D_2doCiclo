using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Buttons[] requiredButtons;
    [SerializeField] private bool requireRightColors;
    [SerializeField] private GameObject door;
    private bool permanentlyOpen = false;

    
    private void Update()
    {
        if (permanentlyOpen)
        {
            door.SetActive(false);
            return;
        }

        if (AllButtons())
        {
            door.SetActive(false);
        }
        else door.SetActive(true);
    }

    public void OpenPermanently()
    {
        permanentlyOpen = true;
        door.SetActive(false);
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
