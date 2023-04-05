using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject kunai;
    public float circleSpeed = 7;
    public float TimeScale;
    public bool canShoot;
    public int dashAmount;
    public int kunaiAmount = 5;
    public float coolDown = 0.7f;
    public float dashSpeed = 8f;
    public float health;
    public float speed = 3f;
    public float damage;
    public string currentState = "Chasing Player";

    Rigidbody2D rb2D;
    Character2dController playerScript;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Character2dController>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        }
    }

    IEnumerator kunaiCoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        canShoot= true;
    }
}
