using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaDialog : MonoBehaviour
{
    Dialog speak;
    public GameObject book;
    public AudioClip obtainBook;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        speak = GetComponent<Dialog>();

        if (Character2dController.hasFrog)
        {
            speak.dialogue[0] = "Hey mija I see you returned.";
            speak.dialogue[1] = "Looks like you found the Rare Frog.";
            speak.dialogue[2] = "Adios Mija,also here is this book to help you and good luck again.";
        }
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speak.index == 2 && !Inventory.hasBook && Character2dController.hasFrog)
        {
            Inventory.hasBook = true;
            GameObject Localbook = Instantiate(book);
            audioSource.PlayOneShot(obtainBook);
            DontDestroyOnLoad(Localbook);
            
            
        }
    }
}
