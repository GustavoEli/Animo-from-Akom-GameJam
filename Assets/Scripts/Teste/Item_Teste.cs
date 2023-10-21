using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Teste : MonoBehaviour
{
    public GameObject [] pl_item = new GameObject[4];
    Image imagem;
    bool confirmador;
    bool retorno_tipo;

    public void Start()
    {

    }

    public bool verifica() {
        switch (gameObject.name) {
            case "livro":
                confirmador = true;
                break;
            case "coca-cola":
                confirmador =  false;
                break;
        }
        return confirmador;
    }

    public bool verifica_tipo_item() {

        foreach (GameObject items in pl_item){
            if (items.name == "livro"){
                retorno_tipo = true;
            }
            else {
                retorno_tipo = false;
            }
        }
        return retorno_tipo;
    }
}
