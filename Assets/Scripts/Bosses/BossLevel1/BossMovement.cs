using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float shadeSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float returnSpeed;

    [Header("Timing")]
    [SerializeField] private float chasingTime;
    [SerializeField] private float stayOnGround;

    private Transform hand;
    private Transform player;
    private Transform zone;

    private Vector3 hitSpot;
    private Vector3 upPosition;

    public Vector3 Hitspot => hitSpot;

    public void Initialize()
    {
        hand = transform.Find("MotherHand");
        zone = transform.Find("Zone");

        player = GameObject.FindGameObjectWithTag("Player").transform;

        hitSpot = zone.position;
        upPosition = hand.position;
    }

    public IEnumerator Chase()
    {
        hitSpot = zone.position;

        float t = 0;

        while (t  < chasingTime)
        {
            hitSpot = Vector3.MoveTowards(hitSpot, player.position, shadeSpeed * Time.deltaTime);

            zone.position = hitSpot;

            t += Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator Fall()
    {
        Vector3 downPosition = zone.position;

        while (Vector3.Distance(hand.position, downPosition) > 0.01f)
        {
            hand.position = Vector3.MoveTowards(hand.position, downPosition, fallSpeed * Time.deltaTime);

            yield return null;
        }

        hand.position = downPosition;
    }

    public IEnumerator WaitOnGround()
    {
        yield return new WaitForSeconds(stayOnGround);
    }

    public IEnumerator ReturnHand()
    {
        while (Vector3.Distance(hand.position, upPosition) > 0.01f)
        {
            hand.position = Vector3.MoveTowards(hand.position, upPosition, returnSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
