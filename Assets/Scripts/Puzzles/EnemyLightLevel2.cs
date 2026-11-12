using UnityEngine;

public class EnemyLightLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject firstCdObject;
    [SerializeField] private GameObject secondCdObject;
    [SerializeField] private GameObject thirdCdObject;
    private int cdCount = 0;
    public void LightNextEvent()
    {
        cdCount++;

        switch (cdCount)
        {
            case 1:firstCdObject.SetActive(true);
                break;
            case 2:secondCdObject.SetActive(true);
                break;
            case 3:thirdCdObject.SetActive(true);
                break;
        }
    }
}