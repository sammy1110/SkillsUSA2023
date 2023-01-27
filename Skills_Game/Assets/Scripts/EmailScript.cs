using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmailScript : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("Computer");
    }

    public void Exit2()
    {
        SceneManager.LoadScene("Computer 1.2");
    }

    public void OpenEmail()
    {
        SceneManager.LoadScene("Email");
    }

    public void OpenEmail2()
    {
        SceneManager.LoadScene("Email 1.2");
    }

    public void CloseComputer1()
    {
        SceneManager.LoadScene("Inside House");
    }

    public void CloseComputer2()
    {
        SceneManager.LoadScene("Inside House 1.2");
    }
}
