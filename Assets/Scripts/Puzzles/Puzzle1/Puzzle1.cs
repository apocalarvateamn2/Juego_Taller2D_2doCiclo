using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    [Header ("Rotation")]
    [SerializeField] private float duration = 5f;
    [SerializeField] private float rightAngle = 60f;
    [SerializeField] private float leftAngle = -60f;

    public bool canMove = true;

    private float invertDirection;
    private float initialz;
    private float timer = 0f;
 
  

    private void Start()
    {
        initialz = transform.eulerAngles.z;
        invertDirection = 1f / duration;
    }

    void Update()
    {
        if (!canMove)
            return;

        timer += Time.deltaTime;

        if(timer >= duration * 2)
        {
            timer = 0f;
        }

        Rotate();
    }

    private void Rotate()
    {
        float t = Mathf.PingPong(timer * invertDirection, 1f);
        float angle = Mathf.Lerp(leftAngle, rightAngle, t);
        transform.rotation = Quaternion.Euler(0, 0, initialz + angle);

    }
}
