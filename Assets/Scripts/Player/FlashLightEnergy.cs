using UnityEngine;
using UnityEngine.UI;

public class FlashLightEnergy : MonoBehaviour
{
    [Header("Charge")]
    [SerializeField] private float maxEnergy = 150f;
    [SerializeField] private float usage = 15f;
    [SerializeField] private float recharge = 10f;


    [Header("UI")]
    [SerializeField] private Image energyBar;

    private float currentEnergy;


    private void Awake()
    {
        currentEnergy = maxEnergy;
        energyBar.fillAmount = 1f;
    }

    private void Update()
    {
        UpdateBar();
    }

    public bool HasEnergy()
    {
        return currentEnergy > 0;
    }

    public void UseEnergy()
    {
        currentEnergy -= usage * Time.deltaTime;
        ClampEnergy();
    }

    public void RechargeEnergy()
    {
        currentEnergy += recharge * Time.deltaTime;
        ClampEnergy();
    }

    private void ClampEnergy()
    {
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    private void UpdateBar()
    {
        float fillAmount = currentEnergy / maxEnergy;
        energyBar.fillAmount = Mathf.Lerp(energyBar.fillAmount, fillAmount, Time.deltaTime * 2.5f);
    }
}
