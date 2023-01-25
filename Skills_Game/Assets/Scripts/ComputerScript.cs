using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerScript : MonoBehaviour
{
    public GameObject player;
    public bool PlayerIsAtTheDesk;
    public float TimeBeforeNextScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheDesk == true)
        {
            StartCoroutine(OpenComputer());
        }
    }

    public IEnumerator OpenComputer()
    {
        yield return new WaitForSeconds(TimeBeforeNextScene);
        SceneManager.LoadScene("Computer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerIsAtTheDesk = true;

        }

    }
}
