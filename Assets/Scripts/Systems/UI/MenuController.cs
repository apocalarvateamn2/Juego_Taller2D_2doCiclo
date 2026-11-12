using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuOptionShake[] options;
    [SerializeField] private RectTransform flashlight;
    [SerializeField] private Vector2 flashlightOffset = new Vector2(-120f, 0f);

    private void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        flashlight.gameObject.SetActive(false);

        foreach (MenuOptionShake option in options)
        {
            RectTransform optionRect = (RectTransform)option.transform;
            bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(optionRect, mousePosition);

            option.SetSelected(isHovered);

            if (isHovered)
            {
                flashlight.gameObject.SetActive(true);
                flashlight.position = (Vector2)optionRect.position + flashlightOffset;
            }
        }
    }
}