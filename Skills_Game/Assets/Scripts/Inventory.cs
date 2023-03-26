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

    private GameObject itemSlot;

    public static bool isOpen;
    CanvasGroup visibility;

    public static int appleAmmo;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i] = transform.GetChild(i).gameObject;
        }

        visibility = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                visibility.alpha = 0;
                isOpen= false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                visibility.alpha = 1;
                isOpen= true;
            }
        }
        ammoCounter.text = "Ammo: " + appleAmmo.ToString();
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
                    inventoryCount--;
                }
            }
    }

    public void removeItem(string name, int amount)
    {
        foreach (GameObject gameObject in items)
        {
            if (name == gameObject.name)
            {
                Item itemScript = gameObject.GetComponent<Item>();
                itemScript.amount -= amount;
                inventoryItems[items.IndexOf(gameObject)].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemScript.amount.ToString();
                if (itemScript.amount <= 0)
                {
                    items.Remove(gameObject);
                    inventoryCount--;
                }
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
        foreach (GameObject gameObject in items)
        {
            if (gameObject.name == name)
            {
                if(name == "Apple" && appleAmmo - 5 *  gameObject.GetComponent<Item>().amount <= -5)
                {
                    removeItem(gameObject, 1);
                    Debug.Log("Father");
                }
            }
        }
    }
}
