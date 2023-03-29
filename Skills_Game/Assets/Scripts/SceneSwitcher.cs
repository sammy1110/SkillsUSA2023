using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Animator blackanim;
    public CinemachineVirtualCamera MainVCam;
    public float maxZoomIn = 3;
    public float time = 2f;
    public bool isTrans;
    public Vector2 localspawn;
    public static Vector2 globalspawn;
    public string sceneName;
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Maya");
        MainVCam = GameObject.FindWithTag("Virtual Cam").GetComponent<CinemachineVirtualCamera>();
    }
    IEnumerator SwitchScene(string scene, float delay)
    {
        SceneSwitcher.globalspawn = localspawn;
        Debug.Log(scene);
        yield return new WaitForSeconds(delay);      
        SceneManager.LoadScene(scene);    
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Vector2.Distance(transform.position, player.transform.position) < 2 && !isTrans) 
        {
            StartCoroutine(SwitchScene(sceneName, time));
            isTrans= true;
            blackanim.SetTrigger("Trans");
        }

        if(isTrans)
        {
            MainVCam.m_Lens.OrthographicSize = Mathf.Lerp(MainVCam.m_Lens.OrthographicSize, maxZoomIn, Time.deltaTime);
        }
    }

    public void Sandbox()
    {
        SceneManager.LoadScene("Testing");
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void ChangeGlobalScene(string name)
    {
        LoadingScreen.sceneName = name;
    }

    public void normalSceneLoader(string name)
    {
        SceneManager.LoadScene(name);
    }
}
