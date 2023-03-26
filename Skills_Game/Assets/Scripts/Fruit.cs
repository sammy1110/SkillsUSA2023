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
            GameObject tempFruit = Instantiate(fruit);
            tempFruit.name = "Apple";
            inventory.addItem(tempFruit, 1);
            Inventory.appleAmmo += 5;
            Destroy(this.gameObject);
        }
    }
}
