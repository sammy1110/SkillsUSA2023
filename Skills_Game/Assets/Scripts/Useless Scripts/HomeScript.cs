using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public GameObject player;
    public bool PlayerIsAtHome;
    public float TimeBeforeNextScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtHome == true)
        {
            StartCoroutine(OpenHome());
        }
    }

    public IEnumerator OpenHome()
    {
        yield return new WaitForSeconds(TimeBeforeNextScene);
        SceneManager.LoadScene("Level 1");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerIsAtHome = true;

        }

    }
}
