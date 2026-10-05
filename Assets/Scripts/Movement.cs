using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("InputAction")]
    [SerializeField] private InputActionReference movement;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector2 direction;
    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction = movement.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed);
        //FlipX();
    }

    //private void FlipX()
    //{
    //    if (direction != Vector2.zero)
    //    {
    //        transform.right = direction;
    //    }
    //}
}
