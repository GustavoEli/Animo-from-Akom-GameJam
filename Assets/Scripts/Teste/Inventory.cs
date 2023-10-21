using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image [] itemImages = new Image[numItemSlot];
    public Item[] items = new Item[numItemSlot];

    public const int numItemSlot = 4;

    public void addItem(Item itemToadd) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                items[i] = itemToadd;
                itemImages[i].sprite = itemToadd.sprite;
                itemImages[i].enabled = true;
                return; //quando achar um slot vazio ele ira parar e sair da função
            }
        }
    }

    public void removeItem(Item itemToremove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToremove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return; //quando achar um slot vazio ele ira parar e sair da função
            }
        }
    }
}
