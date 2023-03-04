using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Vector2 localspawn;
    public static Vector2 globalspawn;
    public string sceneName;
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Maya");
    }
    public void SwitchScene(string sceneName)
    {
        SceneSwitcher.globalspawn = localspawn;
        SceneManager.LoadScene(sceneName);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, player.transform.position) < 2) 
        { 
            SwitchScene(sceneName);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Sandbox()
    {
        SceneManager.LoadScene("Testing");
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
