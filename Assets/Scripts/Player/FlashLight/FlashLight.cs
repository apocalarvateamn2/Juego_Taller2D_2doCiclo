using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private InputActionReference flashLight;

    [Header ("Light")]
    [SerializeField] private GameObject lightObject;
    [SerializeField] private Transform linterna;
    [SerializeField] private GameObject detectionArea;

    [Header("Energy")]
    [SerializeField] private FlashLightEnergy energy;

    private bool inUse = false;

    public bool IsOn => inUse && energy.HasEnergy();

    private void Update()
    {
        LightDirection();

        bool canUse = inUse && energy.HasEnergy();

        lightObject.SetActive(canUse);
        detectionArea.SetActive(canUse);

        if (canUse)
            energy.UseEnergy();
        else if (!inUse)
            energy.RechargeEnergy();
    }

    private void OnEnable()
    {
        flashLight.action.performed += LightManagerOn;
        flashLight.action.canceled += LightManagerOff;
    }

    private void OnDisable()
    {
        flashLight.action.performed -= LightManagerOn;
        flashLight.action.canceled -= LightManagerOff;
    }

    private void LightDirection()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = mouseWorldPosition - linterna.position;

        float angle = Vector2.SignedAngle(Vector2.up, direction);

        linterna.rotation = Quaternion.Euler(0, 0, angle);

        detectionArea.transform.rotation = linterna.rotation;
    }

    private void LightManagerOn(InputAction.CallbackContext context)
    {
        inUse = true;
    }

    private void LightManagerOff(InputAction.CallbackContext context)
    {
        inUse = false;
    }
}
