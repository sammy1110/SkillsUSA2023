using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject player;
    public Inventory inventory;
    public GameObject fruit;
    public string fruitName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.transform.position, transform.position) < 1 && Character2dController.hasFrog)
        {
            switch(fruitName)
            {
                case "Apple":
                    Inventory.appleAmmo += 5;
                    break;

                case "Cherries":
                    Inventory.cherryAmmo += 2;
                    break;

            }
            Character2dController.hasFruit = true;
            GameObject tempFruit = Instantiate(fruit);
            tempFruit.name = fruitName;
            player.GetComponent<Character2dController>().currentWeapon = fruitName;
            inventory.addItem(tempFruit, 1);
            Destroy(this.gameObject);
        }
    }
}
