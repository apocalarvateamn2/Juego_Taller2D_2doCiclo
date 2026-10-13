using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private InputActionReference flashLight;
    [SerializeField] private GameObject lightObject;
    [SerializeField] private Transform linterna;

    [Header ("Charge")]
    [SerializeField] private float maxEnergy = 150f;
    [SerializeField] private float usage = 15f;
    [SerializeField] private float recharge = 10f;

    [Header ("UI")]
    [SerializeField] private Slider energyBar;

    private float currentEnergy;
    private bool inUse = false;

    public bool IsOn => inUse && currentEnergy > 0; //esto es para que el boss sepa que esta prendida la luz

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    private void Update()
    {
        LightDirection();

        energyBar.value = currentEnergy;

        if (inUse && currentEnergy > 0)
        {
            currentEnergy -= usage * Time.deltaTime;
            lightObject.SetActive(true);
        }
        else
        {
            lightObject.SetActive(false);
            currentEnergy += recharge * Time.deltaTime;
        }

        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

        if(currentEnergy <= 0)
        {
            lightObject.SetActive(false);
        }
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
