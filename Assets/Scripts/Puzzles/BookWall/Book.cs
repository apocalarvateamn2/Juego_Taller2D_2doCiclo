using UnityEngine;

public class Book : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openSprite;

    [Header("Timer")]
    [SerializeField] private float openDuration = 5f;

    [Header("Walls")]
    [SerializeField] private GameObject[] walls;

    private SpriteRenderer spriteRenderer;
    private float remainingTime;
    private bool isOpen;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetOpen(false);
    }

    private void Update()
    {
        if (!isOpen) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
            SetOpen(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        remainingTime = openDuration;
        SetOpen(true);
    }

    private void SetOpen(bool open)
    {
        isOpen = open;
        spriteRenderer.sprite = open ? openSprite : closedSprite;

        foreach (GameObject wall in walls)
            wall.SetActive(open);
    }
}