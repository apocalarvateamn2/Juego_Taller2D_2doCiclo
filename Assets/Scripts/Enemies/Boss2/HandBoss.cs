using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform hand;
    [SerializeField] private Transform player;
    [SerializeField] private Light2D zone;

    [Header("HandMovement and Timing")]
    [SerializeField] private float fallSpeed = 40f;
    [SerializeField] private float shadeSpeed = 3f;
    [SerializeField] private float chasingTime = 2f;
    [SerializeField] private float warningTime = 1f;
    [SerializeField] private float stayGroundTime = 1.5f;
    [SerializeField] private float returnSpeed = 20f;
    [SerializeField] private float upY = 11.5f;

    [Header("Win Conditions")]
    [SerializeField] private int requiredEnemies = 10;

    [Header("Combat")]
    [SerializeField] private Vector2 hitBoxSize = new Vector2(3f, 2f);
    [SerializeField] private float stunTime = 2f;

    private Vector3 hitSpot;
    private Movement move;
    private PlayerStats st;
    private int enemiesCrushed;
    private bool isHurt = false;

    //private bool enemyhit = false;

    private void Awake()
    {
        move = player.GetComponent<Movement>();
        st = player.GetComponent<PlayerStats>();
    }
    private void Start()
    {
        zone.enabled = false;
        hitSpot = transform.position;
        StartCoroutine(StartCombat());
    }

    //public void Combat()
    //{
    //    StartCoroutine(StartCombat());
    //}

    IEnumerator StartCombat()
    {
        while (enemiesCrushed < requiredEnemies)
        {
            yield return Chase();
            yield return Warning();
            yield return Fall();

            if (isHurt)
                yield return Stun();
            else
                yield return new WaitForSeconds(1f);

            isHurt = false;
        }

        Destroy(gameObject, 0.5f);
    }

    IEnumerator Chase()
    {
        zone.enabled = false;

        float t = 0;
        while (t < chasingTime)
        {
            hitSpot = Vector3.MoveTowards(hitSpot, player.position, shadeSpeed * Time.deltaTime);
            zone.transform.position = hitSpot;
            t += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Warning()
    {
        zone.transform.position = hitSpot;
        zone.enabled = true;
        zone.color = new Color(1f, 0.6f, 0f, 0.4f);

        float t = 0;

        while (t < warningTime)
        {
            float bright = Mathf.PingPong(t * 3f, 1f);
            zone.color = new Color(1f, 0f, 0f, 0.3f + bright * 0.5f);
            t += Time.deltaTime;
            yield return null;
        }

        zone.enabled = false;
    }

    IEnumerator Fall()
    {
        Vector3 up = hand.localPosition;
        Vector3 down = zone.transform.position;

        while (hand.localPosition.y > down.y)
        {
            hand.localPosition = Vector3.MoveTowards(hand.localPosition, down, fallSpeed * Time.deltaTime);
            yield return null;
        }

        isHurt = Crash();

        if (isHurt)
            yield return Stun();
        else
            yield return new WaitForSeconds(stayGroundTime);

        float t = 0;

        while (t < returnSpeed)
        {
            t += Time.deltaTime;
            float goBack = t / returnSpeed;

            hand.localPosition = Vector3.Lerp(down, up, goBack);
            yield return null;
        }

        zone.enabled = false;
    }

    IEnumerator Stun()
    {
        SpriteRenderer sr = hand.GetComponent<SpriteRenderer>();
        Color original = sr.color;

        float t = 0;

        while (t < stunTime)
        {
            sr.color = (t % 0.5 < 0.25) ? original : Color.red;
            t += Time.deltaTime;
            yield return null;
        }

        sr.color = original;
        hand.localPosition = new Vector3(hand.localPosition.x, upY, hand.localPosition.z);
        zone.enabled = false;
    }

   
    bool Crash()
    {
        bool enemyHit = false;

        Collider2D[] characters = Physics2D.OverlapBoxAll(hand.position, hitBoxSize, 0f);

        foreach (Collider2D character in characters)
        {
            if (character.CompareTag("Enemy"))
            {
                enemyHit = true;
                enemiesCrushed++;
                Destroy(character.gameObject);
            }
            else if (character.CompareTag("Player"))
            {
                st.HealthLoss(40f);
                StartCoroutine(PlayerCrash());
            }
        }

        return enemyHit;
    }

    IEnumerator PlayerCrash()
    {
        move.FreezePlayer();
        yield return new WaitForSeconds(1f);
        move.UnFreezePlayer();
       
    }

    private void OnDrawGizmos()
    {
        if (hand == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hand.position, hitBoxSize);
    }
}
