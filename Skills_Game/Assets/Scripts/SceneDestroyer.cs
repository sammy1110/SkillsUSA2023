using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDestroyer : MonoBehaviour
{
    public GameObject frog;
    public GameObject Rock;


    // Start is called before the first frame update
    void Start()
    {
        if(Character2dController.hasFrog && frog != null)
        {
            Destroy(frog);

            Rock.GetComponent<Dialog>().dialogue[0] = "This is where I first met you.";
            Rock.GetComponent<Dialog>().dialogue[1] = "Nice memories.";
            Rock.GetComponent<Dialog>().dialogue[2] = "Atleast you are safe with me from now on.";           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
