
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementScript : MonoBehaviour
{
    public Vector2 currentPos;
    public Vector2[] positions;
    public float speed;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentPos = positions[Random.Range(0, positions.Length)];
    }

    void FixedUpdate()
    {
       if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), currentPos) > 0.5f)
       {
            rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y) + (currentPos - new Vector2(transform.position.x, transform.position.y)).normalized * speed * Time.deltaTime);
            Debug.Log("doing something");
        }
        else
        {
            currentPos = positions[Random.Range(0, positions.Length)];
        }

        
    }
}
