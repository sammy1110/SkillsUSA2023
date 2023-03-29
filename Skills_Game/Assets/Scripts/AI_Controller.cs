using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class AI_Controller : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public Vector2[] patrolingpos;
    public Vector2 currentpos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentpos = patrolingpos[Random.Range(0, patrolingpos.Length)];
    }

    // Update is called once per frame
    private void Update()
    {
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

    }

    public void hurty()
    {
        Destroy(gameObject);
    }
}
