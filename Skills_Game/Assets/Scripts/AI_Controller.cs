using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AI_Controller : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public Vector2[] patrolingpos;
    public Vector2 currentpos;
    public GameObject player;
    private Character2dController playerScript;
    public float health = 100;
    public Image healthBar;
    CanvasGroup BackGroundFade;

    public AudioClip deathSound;
    public AudioClip hurtNoise;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentpos = patrolingpos[Random.Range(0, patrolingpos.Length)];
        playerScript = player.GetComponent<Character2dController>();
        audioSource = FindObjectOfType<AudioSource>();
        healthBar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        BackGroundFade = healthBar.transform.parent.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        healthBar.fillAmount = health/100;

        healthBar.transform.parent.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.one);

        float step = speed * Time.deltaTime;

        if (target != null && Vector2.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentpos, step);
            if (Vector2.Distance(transform.position, player.transform.position) < 3)
            {
                target = player.transform;
            }

            if (Vector2.Distance(transform.position, currentpos) < 1)
            {
                currentpos = patrolingpos[Random.Range(0, patrolingpos.Length)];
            }
        }      

        if (target !=null && Vector2.Distance(transform.position, target.position) > 3)
        {
            target = null;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 1)
        {
            playerScript.HurtPlayer(20);
        }

        BackGroundFade.alpha = Mathf.Clamp(BackGroundFade.alpha -= Time.deltaTime, 0, 2);

    }

    public void hurty(float hurtAmount)
    {
        BackGroundFade.alpha = 2;
        health = Mathf.Clamp(health - hurtAmount, 0, 100);
        audioSource.PlayOneShot(hurtNoise);

        if (health <=0)
        {
            audioSource.PlayOneShot(deathSound);
            Destroy(gameObject);
        }
    }
}
