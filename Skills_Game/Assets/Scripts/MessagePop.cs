using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePop : MonoBehaviour
{
    public GameObject Message;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Message.SetActive(true);
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(false);
        }
    }
}
