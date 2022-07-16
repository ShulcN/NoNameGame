using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventary : MonoBehaviour
{
    public InventaryDataBase data;
    public List<ItemInventary> items = new List<ItemInventary>();

    public GameObject gameObjShow;
    public GameObject InventoryMainObject;
    public Camera cam;
    public EventSystem ev;
    public int currentID;
    public ItemInventary currentItem;
    public RectTransform movingObject;
    public Vector3 offset;
    public int maxCount;
    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }
        for (int i = 0; i<maxCount; i++) //test
        {
            AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1, 99));

        }
        UpdateInventory();
    }
    public void Update()
    {
        if (currentID != -1)
        {
            MoveObject();
        }
    }
    public void AddItem(int id, Item item, int count )
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[item.id].img;
        if (count>1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();//cheldren
            
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddInvetoryItem(int id, ItemInventary invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;
        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();//cheldren

        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();
            ItemInventary ii = new ItemInventary();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
            Button tempButton = newItem.GetComponent<Button>();
            tempButton.onClick.AddListener(delegate { SelectObject(); });
            items.Add(ii);

        }
    }
    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }
            items[i].itemGameObj.GetComponentInChildren<Image>().sprite = data.items[items[i].id].img;
        }
    }
    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(ev.currentSelectedGameObject.name);
            currentItem = CopyInvetoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;
            AddItem(currentID, data.items[0], 0);
        } else
        {
            AddInvetoryItem(currentID, items[int.Parse(ev.currentSelectedGameObject.name)]);
            AddInvetoryItem(int.Parse(ev.currentSelectedGameObject.name), currentItem);
            currentID = -1;
            movingObject.gameObject.SetActive(false);
        }
    }
    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }
    public ItemInventary CopyInvetoryItem(ItemInventary old)
    {
        ItemInventary New = new ItemInventary();
        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;
        return New;
    }
}
[System.Serializable]
public class ItemInventary
{
    public int id;
    public GameObject itemGameObj;
    public int count;
}
