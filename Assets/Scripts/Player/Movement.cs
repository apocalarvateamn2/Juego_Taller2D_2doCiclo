using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("InputAction")]
    [SerializeField] private InputActionReference movement;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float acelerationSpeed;
    [SerializeField] private float decelerationSpeed;

    private Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = movement.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = direction * speed;

        float currentAceleration = direction != Vector2.zero ? acelerationSpeed : decelerationSpeed;

        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, currentAceleration * Time.fixedDeltaTime);  
    }

    public void FreezePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void UnFreezePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
