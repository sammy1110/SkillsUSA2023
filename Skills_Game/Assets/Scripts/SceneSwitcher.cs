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
    public GameObject prompt;
    public GameObject promptPrefab;

    public void Start()
    {
        player = GameObject.Find("Maya");
        MainVCam = GameObject.FindWithTag("Virtual Cam").GetComponent<CinemachineVirtualCamera>();
        prompt = Instantiate(promptPrefab, transform);
        prompt.transform.localPosition = new Vector2(0.5f, 0.1f);

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Character2dController.hasHud= true;
        }
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
        if(Vector2.Distance(transform.position, player.transform.position) < 1 && !isTrans) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(SwitchScene(sceneName, time));
                isTrans = true;
                blackanim.SetTrigger("Trans");
            } 
            prompt.SetActive(true);
            prompt.transform.position = player.transform.position + Vector3.up;
        }
        else
        {
            prompt.SetActive(false);
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
