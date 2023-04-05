using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    public LayerMask Fwog;
    public GameObject player;
    public GameObject healthBar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.transform.position, transform.position)< 1) 
        {
            Character2dController.hasFrog= true;
            Destroy(gameObject);
            GameObject.Find("Canvas").transform.Find("HealthBackGround").GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("HealthBackGround").GetChild(1).gameObject.SetActive(true);
        }
    }
}
