using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;


public class LightDetection : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private Light2D spotLight;
    [SerializeField] private Puzzle1 lightController;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private LayerMask detectionLayer; 
    private Transform player;
    private float rayRange = 8f;
    private float colorCd = 2f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lightController = GetComponentInParent<Puzzle1>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            RaycastDetection();
        }
    }

    private bool DetectPlayerWithRayCast(Transform origin, Transform target, float range, LayerMask layer)
    {
        if (Vector2.Distance(origin.position, target.position) > range)
            return false;

        Vector2 direction = (target.position - origin.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(origin.position, direction, range, layer);

        return hit.collider != null && hit.collider.CompareTag("Player");
    }

    private void RaycastDetection()
    {
        if (DetectPlayerWithRayCast(rayOrigin, player, rayRange, detectionLayer))
        {
            PlayerOnLight();
        }
    }

    private void PlayerOnLight()
    {
        Destroy(player.gameObject, 1f);
        playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeAll;
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
    //private void OnDrawGizmos()
    //{
    //    if (player == null)
    //        return;
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(rayOrigin.position, player.position);
    //}

    IEnumerator ChangeColor()
    {
        spotLight.color = Color.red;
        yield return new WaitForSeconds(colorCd);
        spotLight.color = Color.white;
    }
}
