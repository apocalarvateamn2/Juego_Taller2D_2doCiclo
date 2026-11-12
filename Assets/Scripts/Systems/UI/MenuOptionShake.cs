using UnityEngine;

public class MenuOptionShake : MonoBehaviour
{
    [SerializeField] private float shakeAmount = 3f;   // intensidad (en píxeles de UI)
    [SerializeField] private float shakeSpeed = 25f;   // qué tan rápido tiembla

    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private bool isSelected;
    private float seed;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        seed = Random.value * 100f; // para que cada opción tiemble distinto
    }

    private void Update()
    {
        if (isSelected) return;

        float offsetX = (Mathf.PerlinNoise(seed, Time.time * shakeSpeed) - 0.5f) * 2f * shakeAmount;
        float offsetY = (Mathf.PerlinNoise(seed + 50f, Time.time * shakeSpeed) - 0.5f) * 2f * shakeAmount;

        rectTransform.anchoredPosition = originalPosition + new Vector2(offsetX, offsetY);
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;

        if (isSelected)
            rectTransform.anchoredPosition = originalPosition;
    }
}