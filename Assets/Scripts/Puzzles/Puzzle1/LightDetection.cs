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
    private Transform player;
    private float colorCd = 2f;
    //private bool isOnLight;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lightController = GetComponentInParent<Puzzle1>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        isOnLight = true;
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            RaycastDetection();
        }
    }

    private void RaycastDetection()
    {
        Vector2 direction = player.position - rayOrigin.position;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, direction);


        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject, 2f);
                playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeAll;
                lightController.canMove = false;
                StartCoroutine(ChangeColor());
            }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        isOnLight = false;
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
