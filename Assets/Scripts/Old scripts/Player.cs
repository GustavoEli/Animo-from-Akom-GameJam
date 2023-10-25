using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocidade; //valor que vai ser somado com a posição, fazendo ele andar

    const int numItens = 4;
    public GameObject[] items = new GameObject[numItens];           //array de inventario
    public Image[] imagemItem = new Image[numItens];

    public Vector2 espaco;
    string nome_objeto;
    public string verifica_objeto;
    public bool pegou_item;

    public Transform paginas_canvas;
    public bool estaLendo;

    Animator animador; //gerenciador de animação
    SpriteRenderer sprite; //manipulador do sprite q esta sendo usado, por exemplo, virar a imagem ao contrario

    void Start()
    {
        //ele pega os componentes que estao no objeto(ver no inspector) para poder usa-los
        sprite = GetComponent<SpriteRenderer>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(Time.timeScale);
        SairDiario();
        Controles();
    }

    //função dos controles que o jogador movimenta
    public void Controles()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
            animador.SetBool("andar", true);
            sprite.flipX = false;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
            animador.SetBool("andar", true);
            sprite.flipX = true;
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);
            animador.SetBool("andar", true);
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * velocidade * Time.deltaTime);
            animador.SetBool("andar", true);
        }
        else
        {
            animador.SetBool("andar", false);
        }

        #region antigo tira item
        /*if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(items[0], transform.position, Quaternion.identity);
            items[0] = null;
            Debug.Log(items[0]);
        }*/
        #endregion
    }

    public void adicionaItem(GameObject adicionaItem)
    {
        for (int i = 0; i <= items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = adicionaItem.gameObject;
                imagemItem[i].sprite = adicionaItem.GetComponent<SpriteRenderer>().sprite;
                imagemItem[i].enabled = true;
                return;
            }
        }
    }

    public void removeItem(GameObject ItemRemover)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == ItemRemover)
            {
                items[i] = null;
                imagemItem[i].sprite = null;
                imagemItem[i].enabled = false;
                return;
            }
        }
    }

    public void verifica_item(GameObject gameObject)
    {
        switch (gameObject.name)
        {
            case "livro":
                verifica_objeto = gameObject.name;
                break;

            case "coca":
                verifica_objeto = gameObject.name;
                break;
            case "jam":
                verifica_objeto = gameObject.name;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "item":
                if (Input.GetKeyDown(KeyCode.P))
                {
                    adicionaItem(collision.gameObject);
                    verifica_item(collision.gameObject);
                    collision.gameObject.SetActive(false);
                    pegou_item = true;

                    Debug.Log("Objeto: " + items[0].name + " entrou no inventario");
                }
                break;

            case "descarga":
                controles_descarga(collision.gameObject);
                break;

            case "diario":
                if (Input.GetKeyDown(KeyCode.E)){
                    Time.timeScale = 0;
                    estaLendo = true;
                    paginas_canvas.gameObject.SetActive(true);
                }
                break;
        }
        #region codigo guia antigo dessa area
        /*if (collision.gameObject.tag == "item")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                adicionaItem(collision.gameObject);
                verifica_item(collision.gameObject);
                collision.gameObject.SetActive(false);
                pegou_item = true;

                Debug.Log("Objeto: " + items[0].name + " entrou no inventario");
                //inventario[0] = GameObject.FindGameObjectWithTag("dialogo");
                //Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "descarga")
        {
            controles_descarga(collision.gameObject);
        }*/
        #endregion
        //verifica_diario(collision);

        if (collision.gameObject.name == "layer") {
            sprite.sortingLayerName = "Fundo";
        } else {
            sprite.sortingLayerName = "Default";
        }

        if (collision.gameObject.name == "testeLayer" || collision.gameObject.name == "layerSala"){
            sprite.sortingLayerName = "Moveis";

        } else {
            sprite.sortingLayerName = "Default";
        }

        if (collision.gameObject.name == "diario") {
            if (Input.GetKeyDown(KeyCode.E)) {
                Time.timeScale = 0;
                estaLendo = true;
                paginas_canvas.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "testeLayer" || collision.gameObject.name == "layerSala" ||
            collision.gameObject.name == "layerCozinha"){
            sprite.sortingLayerName = "Moveis";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "layerSala") {
            sprite.sortingLayerName = "Default";
        }
    }

    public void SairDiario()
    {
        if (Input.GetKeyDown(KeyCode.R) && estaLendo)
        {
            Time.timeScale = 1;
            estaLendo = false;
            paginas_canvas.gameObject.SetActive(false);
        }
    }

    public void controles_descarga(GameObject gameObject)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)){
            verificaDescargas(gameObject, 0);

        } else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)){
            verificaDescargas(gameObject, 1);

        } else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)){
            verificaDescargas(gameObject, 2);

        } else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)){
            verificaDescargas(gameObject, 3);
        }
    }

    public void verificaDescargas(GameObject gameObject, int indice) {

        switch (gameObject.name) {

            case "descarga_armario":
                if (items[indice].name == "calça" || items[indice].name == "camisa1" || items[indice].name == "camisa2"){

                    items[indice].SetActive(false);
                    items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    removeItem(items[indice]);
                }
                break;

            case "descarga_pia":
                if (items[indice].name == "pratos_sujos"){
                    items[indice].SetActive(false);
                    items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    removeItem(items[indice]);
                }
                break;

            case "descarga_lixo":
                if (items[indice].name == "latas" || items[indice].name == "racao"){

                    items[indice].SetActive(false);
                    items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    removeItem(items[indice]);
                }
                break;
        }
    }

    #region velho codigo de descarga
    /*public void verificaRoupa(int indice, GameObject gameObject)
    {

        if (gameObject.name == "descarga_armario" && items[indice].name == "calça")
        {
            Debug.Log("Funciona");
            items[indice].SetActive(false);
            items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            removeItem(items[indice]);

        }
        else if (gameObject.name == "descarga_armario" && items[indice].name == "camisa1")
        {

            items[indice].SetActive(false);
            items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            removeItem(items[indice]);
        }
        else if (gameObject.name == "descarga_armario" && items[indice].name == "camisa2")
        {

            items[indice].SetActive(false);
            items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            removeItem(items[indice]);
        }
    }

    public void verificaPia(int indice, GameObject gameObject)
    {

        if (gameObject.name == "descarga_pia" && items[indice].name == "pratos_sujos")
        {

            items[indice].SetActive(false);
            items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            removeItem(items[indice]);

        }
    }

    public void verificaLixo(int indice, GameObject gameObject)
    {

        if (gameObject.name == "descarga_lixo" && items[indice].name == "latas")
        {

            items[indice].SetActive(false);
            items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            removeItem(items[indice]);

        }
        else if (gameObject.name == "descarga_lixo" && items[indice].name == "racao")
        {

            items[indice].SetActive(false);
            items[indice].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            removeItem(items[indice]);
        }
    }*/
    #endregion
}
