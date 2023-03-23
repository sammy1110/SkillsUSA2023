using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject player;
    public Inventory inventory;
    public GameObject fruit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.transform.position, transform.position) < 1 && Character2dController.hasFrog)
        {
            Character2dController.hasFruit = true;
            inventory.addItem(Instantiate(fruit), 1);
            Destroy(this.gameObject);
        }
    }
}
