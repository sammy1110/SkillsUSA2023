using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image loadingBar;
    public float loadingSpeed = 0.2f;
    public static string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loadingBar.fillAmount += loadingSpeed * Time.deltaTime;
        if(loadingBar.fillAmount >= 1)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
