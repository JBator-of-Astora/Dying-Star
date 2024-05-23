using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    List<Item> items;
    public GameObject itemPrefab;

    void AddItem(string name) {

        for (int i = 0; i < items.Count; i++) {

            if (items[i].get_name() == name) {

                items[i].gain_duplicate();
                return;
            }
        }

        GameObject newItem = Instantiate(Resources.Load<GameObject>(name));
        newItem.transform.parent = transform;

        items.Add(newItem.GetComponent<Item>());
    }

    void Start() {

        items = new List<Item>();
        SelectionOption.itemSelected += AddItem;
    }
}
