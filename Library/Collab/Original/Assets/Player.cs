using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    short vida; //contador de vida
    public float velocidade; //valor que vai ser somado com a posição, fazendo ele andar
    GameObject [] inventario = new GameObject [3]; //array de inventario

    Animator animador; //gerenciador de animação
    SpriteRenderer sprite; //manipulador do sprite q esta sendo usado, por exemplo, virar a imagem ao contrario

    // Start is called before the first frame update
    void Start()
    {
        //ele pega os componentes que estao no objeto(ver no inspector) para poder usa-los
        sprite = GetComponent<SpriteRenderer>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Controles();
    }

    //função dos controles que o jogador movimenta
    public void Controles() {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            Instantiate(inventario[0],transform.position,Quaternion.identity);
            inventario[0] = null;
            //inventario[0].SetActive(false);

            Debug.Log(inventario[0]);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "livro") {
            Debug.Log("Entrou");
            if (Input.GetKeyDown(KeyCode.P))
            {
                inventario[0] = GameObject.FindGameObjectWithTag("dialogo");
                //inventario[0] = collision.gameObject;
                
                Debug.Log("Objeto: " + inventario[0].name + " entrou no inventario");
            }
        }
    }
}
