using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collided;
    public float speed = 1.0f;
    public Rigidbody2D rb2D;
    public float lifetime = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb2D= GetComponent<Rigidbody2D>();
        StartCoroutine(destroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == collided) 
        {
            Destroy(gameObject);
        }

        collision.gameObject.SendMessage("hurty", 15);
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Debug.Log("why did you do that");
    }
}
