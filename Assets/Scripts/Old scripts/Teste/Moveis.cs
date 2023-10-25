using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveis : MonoBehaviour
{
    public Text textBox; //pega a caixa de texto na janela do unity atraves do inspector do objeto
    string[] textos;
    int pula_fala;
    bool inicia_fala;

    // Start is called before the first frame update
    void Start()
    {
        pula_fala = 1;
        inicia_fala = false;
        textos = new string[3];
        textos[0] = "Coroa";
        textos[1] = "virus";
        textos[2] = "cerveja";
    }

    // Update is called once per frame
    void Update()
    {
        if (inicia_fala) { //verifica o modo de fala
            dialogos();
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cursor") {
            if (Input.GetMouseButtonDown(0) && inicia_fala == false) {
                inicia_fala = true; //quando o mouse é clicado inicia o modo de fala
            }
        }
    }

    public void dialogos() { //muda as falas

        switch (pula_fala)
        {
            case 1:
                //não tem nada
                break;

            case 2:
                textBox.text = textos[0];
                break;

            case 3:
                textBox.text = textos[1];
                break;

            case 4:
                textBox.text = textos[2];
                break;

            default:
                textBox.text = "";
                inicia_fala = false;
                pula_fala = 1;
                break;
        }

        if (inicia_fala && Input.GetMouseButtonDown(0)){ //muda de acordo com os clicks do mouse as falas para aparecer
            pula_fala++;
        }
    }

}
