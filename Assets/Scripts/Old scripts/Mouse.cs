using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    //Vector3 posicao;
    Ray raio;
    RaycastHit hit;
    //GameObject sistema;

    void Start()
    {
        Cursor.visible = false; // deixa o cursor real do mouse invisivel quando o jogo se inicia
        
        //Cursor.SetCursor(texture, mouse_posicao, cursor);
    }

    void Update()
    {
        Vector3 pos = Input.mousePosition; //ele pega a posição do mouse e atualiza
        pos.z = transform.position.z - Camera.main.transform.position.z; //define a distância do mouse da camera
        transform.position = Camera.main.ScreenToWorldPoint(pos); //transforma a posição em pixel do mouse em valor se não me engano
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ob1") {
            if (Input.GetMouseButtonDown(0)) {


                //Debug.Log("ob1 foi clicado");
            }
        }

        if (collision.gameObject.name == "ob2") {
            if (Input.GetMouseButtonDown(0)) {
                //Debug.Log("ob2 foi clicado");
            }
        }

    }

}
