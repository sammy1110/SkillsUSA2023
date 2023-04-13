using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public int index;

    public float typingSpeed;
    public bool playerIsClose;

    public GameObject contButton;
  

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        //{
            //if(dialoguePanel.activeInHierarchy)
           // {
               // zeroText();
            //}//else
            //{
                //dialoguePanel.SetActive(true);
                //StartCoroutine(Type());
            //}

        //}

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            if(dialoguePanel.activeSelf)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            else
            {
                dialogueText.text = "";
                index = 0;
                dialoguePanel.SetActive(false);
                break;
            }
        }
    }


    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Type());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);


        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());

        }else
        {
            zeroText();

        }
        Debug.Log("button press");
    }
  


}
