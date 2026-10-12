using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightDetection : MonoBehaviour
{
    [Header ("Light")]
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private Light2D spotLight;

    [Header ("Detection")]
    [SerializeField] private LayerMask detectionLayer;
    //[SerializeField] private float rayRange = 8f;

    [Header ("Settings")]
    [SerializeField] private float colorCd = 2f;

    private Transform player;
    private PlayerStats playerSt;
    private Movement playerMovement;
    private Puzzle1 lightController;
 

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerMovement = player.GetComponent<Movement>();
        playerSt = player.GetComponent<PlayerStats>();

        lightController = GetComponentInParent<Puzzle1>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            RaycastDetection();
        }
    }

    private bool DetectPlayerWithRayCast(Transform origin, Transform target, LayerMask layer)
    {
        //if (Vector2.Distance(origin.position, target.position) > range)
        //    return false;

        Vector2 direction = (target.position - origin.position).normalized;
        float distance = Vector2.Distance(origin.position, target.position);

        RaycastHit2D hit = Physics2D.Raycast(origin.position, direction, distance, layer);

        if(hit.collider != null)
            return hit.collider.CompareTag("Player");

        return false;
    }
     

    private void RaycastDetection()
    {
        if (DetectPlayerWithRayCast(rayOrigin, player, detectionLayer))
        {
            PlayerOnLight();
        }
    }

    private void PlayerOnLight()
    {
        playerSt.HealthLoss(100f);
        playerMovement.FreezePlayer();
        lightController.canMove = false;
        StartCoroutine(ChangeColor());
    }
    //private void RaycastDetection()
    //{
    //    Vector2 direction = (player.position - rayOrigin.position).normalized;

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, direction, detectionLayer);


    //    if (hit.collider != null)
    //    {
    //        if (hit.collider.CompareTag("Player"))
    //        {
    //            Destroy(hit.collider.gameObject, 2f);
    //            playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeAll;
    //            lightController.canMove = false;
    //            StartCoroutine(ChangeColor());
    //        }
    //    }
    //}

    private void OnDrawGizmos()
    {
        if (player == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, player.position);
    }

    IEnumerator ChangeColor()
    {
        spotLight.color = Color.red;
        yield return new WaitForSeconds(colorCd);
        spotLight.color = Color.white;
    }
}
