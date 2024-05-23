using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    private int amount;
    public TextMeshProUGUI itemCounter;
    public ItemData itemData;

    public void Start() {

        TooltipTrigger trigger = GetComponent<TooltipTrigger>();
        trigger.header = itemData.name;
        trigger.content = itemData.content;

        Image image = GetComponent<Image>();
        image.sprite = itemData.image;

        amount = 1;
        itemCounter.text = amount.ToString();
    }

    public void gain_duplicate() {

        amount++;
        itemCounter.text = amount.ToString();
    }

    public string get_name() {

        return itemData.name;
    }

    public virtual void get_attack() {

        Debug.Log("Nothing");
    }
}
