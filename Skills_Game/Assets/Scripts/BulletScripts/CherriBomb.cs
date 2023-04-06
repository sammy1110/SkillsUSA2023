using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherriBomb : MonoBehaviour
{
    Rigidbody2D rb2D;
    public LayerMask layerMask;

    public float radius = 3f;

    public float speed = 5f;
    public float explodeTime = 1f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.TransformDirection(Vector3.up * speed);
        StartCoroutine(blowUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator blowUp()
    {
        yield return new WaitForSeconds(explodeTime);
        Collider2D[] closepeople = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        foreach(Collider2D gameObject in closepeople)
        {
            gameObject.SendMessage("hurty", 50);
        }
        Instantiate(explosion, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
