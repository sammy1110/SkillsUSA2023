using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject kunai;
    public float circleSpeed = 7;
    public float TimeScale;
    public bool canShoot;
    public int dashAmount;
    public int kunaiAmount = 5;
    public float KunaicoolDown = 0.7f;
    public float dashSpeed = 8f;
    public float health;
    public float speed = 3f;
    public float damage;
    public float dashCoolDown;
    public bool canDash;
    public string currentState = "Chasing Player";
    public float actualAlpha;
    public float TransTime = 3;

    Rigidbody2D rb2D;
    Character2dController playerScript;
    GameObject player;
    GameObject healthBarBackGround;
    CanvasGroup healthAlpha;
    Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Character2dController>();
        rb2D = GetComponent<Rigidbody2D>();
        healthAlpha = transform.GetChild(0).GetComponent<CanvasGroup>();
        healthBarBackGround = healthAlpha.transform.GetChild(0).gameObject;
        healthBar = healthBarBackGround.transform.GetChild(0).GetComponent<Image>();
        Invoke("StartOff", 3);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / 200;

        healthBarBackGround.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.one);

        healthAlpha.alpha = actualAlpha;
        actualAlpha -= Time.deltaTime;

        switch (currentState)
        {
            case "Chasing Player":
                transform.right = player.transform.position - transform.position;
                if (canShoot)
                {
                    Instantiate(kunai, transform.position, transform.rotation);
                    canShoot= false;
                }
                rb2D.AddForce(new Vector3(Mathf.Sin(Time.time * TimeScale) * circleSpeed, Mathf.Sin((Time.time-0.5f) * TimeScale) * circleSpeed, 0));
                rb2D.AddForce((player.transform.position - transform.position) * speed);
                Debug.Log(new Vector3(Mathf.Sin(Time.time * TimeScale) * speed, Mathf.Sin(Time.time * TimeScale) * speed, 0));
                break;
           case "StaringDownPlayer":
                transform.right = player.transform.position - transform.position;
                if (canDash)
                {
                    StartCoroutine(restoreDash());
                    rb2D.AddForce((player.transform.position - transform.position).normalized * dashSpeed, ForceMode2D.Impulse);
                }

                if (health <= 100)
                {
                    kunaiAmount = 3;
                    currentState = "Transform";
                    StartCoroutine(transformation());
                }

                break;

          case "PhaseTwo":
                transform.right = player.transform.position - transform.position;

                if (canShoot && kunaiAmount > 0)
                {
                    Destroy(Instantiate(kunai, transform.position, transform.rotation), 3);
                    StartCoroutine(kunaiCoolDown());
                    kunaiAmount--;
                }
                else if (kunaiAmount == 0)
                {
                    currentState = "Dashing";
                    dashCoolDown = 0.5f;
                    dashAmount = 6;
                }
                break;
            case "Dashing":
                transform.right = player.transform.position - transform.position;

                if (canDash && dashAmount > 0)
                {
                    dashAmount--;
                    StartCoroutine(restoreDash());
                    rb2D.AddForce((player.transform.position - transform.position).normalized * dashSpeed, ForceMode2D.Impulse);
                }
                else if (dashAmount == 0)
                {
                    currentState = "PhaseTwo";
                    kunaiAmount = 3;
                }
                break;
            case "Transform":
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("HurtPlayer", 20);
        }
    }

    IEnumerator kunaiCoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(KunaicoolDown);
        canShoot = true;
    }

    IEnumerator restoreDash()
    {
        canDash= false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash= true;
    }

    IEnumerator transformation()
    {
        yield return new WaitForSeconds(TransTime);
        currentState = "PhaseTwo";
    }

    public void hurty(float amount)
    {
        health -= amount;
        actualAlpha = 2;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void StartOff()
    {
        currentState = "StaringDownPlayer";
    }
}
