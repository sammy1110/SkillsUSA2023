using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI ammoCounter;
    public List<GameObject> items = new List<GameObject>();
    public GameObject[] inventoryItems = new GameObject[12];
    public int inventoryCount = 0;

    Character2dController player;

    private GameObject itemSlot;

    public static bool isOpen;
    CanvasGroup visibility;

    public static int appleAmmo;
    public static int cherryAmmo;

    public static bool hasBook;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i] = transform.GetChild(i).gameObject;
        }

        visibility = GetComponent<CanvasGroup>();
        visibility.interactable= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character2dController>();
        }

        switch(player.currentWeapon)
        {
            case "Apple":
                ammoCounter.text = "Ammo: " + appleAmmo.ToString();
                break;

            case "Cherries":
                ammoCounter.text ="Ammo: " + cherryAmmo.ToString();
                break;
            default:
                break;
        }

        if(isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                visibility.alpha = 0;
                visibility.interactable = false;
                isOpen = false;
                visibility.blocksRaycasts = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                visibility.alpha = 1;
                visibility.interactable = true;
                isOpen= true;
                visibility.blocksRaycasts = true;
            }
        }     
    }

    public void addItem(GameObject item, int amount)
    {
        if(items.Count < 12)
        {
            Item itemScript = item.GetComponent<Item>();
            foreach (GameObject gameObject in items)
            {
                if(gameObject.name == item.name)
                {
                    gameObject.GetComponent<Item>().amount += amount;
                    inventoryItems[items.IndexOf(gameObject)].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = gameObject.GetComponent<Item>().amount.ToString();
                    Destroy(item);
                    return;
                }
            }

            if(itemScript.amount < itemScript.Limit)
            {
                itemScript.amount += amount;
            }
            items.Add(item);
            Debug.Log(item);
            inventoryItems[inventoryCount].transform.GetChild(1).GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            inventoryItems[inventoryCount].transform.GetChild(1).gameObject.SetActive(true);
            inventoryItems[inventoryCount].transform.GetChild(1).gameObject.name = item.name;
            inventoryItems[inventoryCount].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemScript.amount.ToString();
            inventoryCount++;
        }
    }

    public void removeItem(GameObject item, int amount)
    {
        if (items.Contains(item))
        {
            Item itemScript = item.GetComponent<Item>();
            itemScript.amount -= amount;
            inventoryItems[items.IndexOf(item)].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemScript.amount.ToString();
            if (itemScript.amount <= 0)
            {
                inventoryItems[items.IndexOf(item)].transform.GetChild(1).gameObject.SetActive(false);
                inventoryItems[items.IndexOf(item)].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = null;
                items.Remove(item);
                Debug.Log(item.name);
                Destroy(item);
                inventoryCount--;
            }
        }       
    }

    public void HighLightSquare(GameObject square)
    {
        square.SetActive (true);
    }

    public void UnHighLightSquare(GameObject square)
    {
        square.SetActive(false);
    }

    public void fruitBeGone(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
            {
                GameObject gameObject = items[i];

                if(name == "Apple" && appleAmmo - 5 *  gameObject.GetComponent<Item>().amount <= -5)
                {
                    removeItem(gameObject, 1);
                    Debug.Log("Gone");
                }

                if (name == "Cherries" && cherryAmmo - 2 * gameObject.GetComponent<Item>().amount <= -2)
                {
                    removeItem(gameObject, 1);
                    Debug.Log("Gone");
                }
            }
        }
    }

    public void SwitchWeapon(GameObject gameObject)
    {
        player.SwitchWeapon(gameObject.name);
    }
}
