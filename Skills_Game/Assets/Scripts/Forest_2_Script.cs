using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Forest_2_Script : MonoBehaviour
{

    public GameObject player;
    public bool PlayerIsAtTheForest;
    public float TimeBeforeNextScene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheForest == true)
        {
            StartCoroutine(OpenForest());
        }
    }

    public IEnumerator OpenForest()
    {
        yield return new WaitForSeconds(TimeBeforeNextScene);
        SceneManager.LoadScene("Forest 1.2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerIsAtTheForest = true;

        }

    }

}
