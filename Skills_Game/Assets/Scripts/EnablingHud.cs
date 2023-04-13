using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingHud : MonoBehaviour
{
    SceneSwitcher sceneSwitcher;
    GameObject player;
    Character2dController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Maya");
        sceneSwitcher = GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < 1 && !sceneSwitcher.isTrans && Input.GetKeyDown(KeyCode.E))
        {
            EnableHud();
        }
    }

    private void EnableHud()
    {
        Character2dController.hasHud = true;
    }
}
