using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Character2dController.hasFrog)
        {
            GetComponent<Dialog>().dialogue[0] = "Hey mom you're back!";
            GetComponent<Dialog>().dialogue[1] = "Looks like you found the Rare Frog as well.";
            GetComponent<Dialog>().dialogue[2] = "Well I dont wanna stop you go on with your adventure.";
            GetComponent<Dialog>().dialogue[3] = "Meow!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
