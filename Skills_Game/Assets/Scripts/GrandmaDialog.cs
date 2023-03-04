using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Character2dController.hasFrog)
        {
            GetComponent<Dialog>().dialogue[0] = "Hey mija I see you returned.";
            GetComponent<Dialog>().dialogue[1] = "Looks like you found the Rare Frog.";
            GetComponent<Dialog>().dialogue[2] = "Well go on and explore mija but be weary weird things have been going on.";
            GetComponent<Dialog>().dialogue[3] = "Adios Mija and good luck again.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
