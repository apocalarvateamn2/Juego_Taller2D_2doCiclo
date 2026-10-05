using System.Threading;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    [SerializeField] private float duration = 5f;
    [SerializeField] private float rightAngle = 60f;
    [SerializeField] private float leftAngle = -60f;
    private float initialz;
    public bool canMove = true;

    private void Start()
    {
        initialz = transform.eulerAngles.z;
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
        float t = Mathf.PingPong(timer / duration, 1f);
        float angle = Mathf.Lerp(leftAngle, rightAngle, t);
        transform.rotation = Quaternion.Euler(0, 0, initialz + angle);

    }
}
