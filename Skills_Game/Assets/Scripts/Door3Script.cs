using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door3Script : MonoBehaviour
{

    public GameObject player;
    public float TimeBeforeNextScene;
    public bool PlayerIsAtTheDoor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheDoor == true)
        {
            StartCoroutine(OpenDoor());
        }
    }

    public IEnumerator OpenDoor()
    {

        yield return new WaitForSeconds(TimeBeforeNextScene);
        SceneManager.LoadScene("Inside House 1.2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerIsAtTheDoor = true;
        }

    }
}
