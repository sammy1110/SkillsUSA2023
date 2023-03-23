using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject[] inventoryItems = new GameObject[12];
    public int inventoryCount = 0;

    private GameObject itemSlot;

    public bool isOpen;
    CanvasGroup visibility;

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
    }

    public void addItem(GameObject item, int amount)
    {
        if(items.Count < 12)
        {
            Item itemScript = item.GetComponent<Item>();
            if(itemScript.amount < itemScript.Limit)
            {
                itemScript.amount += amount;
            }
            items.Add(item);
            Debug.Log(item);
            inventoryItems[inventoryCount].transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            inventoryItems[inventoryCount].transform.GetChild(0).gameObject.SetActive(true);
            inventoryItems[inventoryCount].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemScript.amount.ToString();
            inventoryCount++;
        }
    }

    public void removeItem(GameObject item, int amount)
    {
        foreach(GameObject gameObject in items)
        {
            if (items.Contains(gameObject))
            {
                Item itemScript = item.GetComponent<Item>();
                itemScript.amount -= amount;
                if(itemScript.amount < 0)
                {
                    items.Remove(gameObject);
                    inventoryCount--;
                }
            }
        }
    }
}
