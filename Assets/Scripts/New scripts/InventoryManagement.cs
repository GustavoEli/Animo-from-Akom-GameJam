using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagement : MonoBehaviour
{
    [SerializeField] Image[] imageItem = new Image[4];

    public void AddItem(GameObject addItem, GameObject [] itens) {
        for (int i = 0; i <= itens.Length; i++) {
            if (itens[i] == null) {
                itens[i] = addItem.gameObject;
                imageItem[i].sprite = addItem.GetComponent<SpriteRenderer>().sprite;
                imageItem[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(GameObject removeItem, GameObject [] itens) {

        for (int i = 0; i < itens.Length; i++) {
            if (itens[i] == removeItem) {
                itens[i] = null;
                imageItem[i].sprite = null;
                imageItem[i].enabled = false;
                return;
            }
        }
    }

    public void LeaveObject(int index, GameObject [] itens) {
        itens[index].SetActive(false);
        itens[index].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    public void VerifyLowerPoint(GameObject gameObject, int indice, GameObject[] itens) {

        switch (gameObject.name) {
            case "descarga_armario":
                if (itens[indice].name == "calça" || itens[indice].name == "camisa1" || itens[indice].name == "camisa2") {
                    LeaveObject(indice, itens);
                    RemoveItem(itens[indice], itens);
                }
                break;

            case "descarga_pia":
                if (itens[indice].name == "pratos_sujos") {
                    LeaveObject(indice, itens);
                    RemoveItem(itens[indice], itens );
                }
                break;

            case "descarga_lixo":
                if (itens[indice].name == "latas" || itens[indice].name == "racao") {
                    LeaveObject(indice, itens);
                    RemoveItem(itens[indice], itens);
                }
                break;
        }
    }
}
