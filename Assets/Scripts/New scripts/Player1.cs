 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] GameObject[] itens = new GameObject[4];
    [SerializeField] Image[] imageItem = new Image[4];
    [SerializeField] Transform canvasPages;

    bool isReading;
    Animator animator;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        Controls();
    }

    private void Controls() {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
            animator.SetBool("andar", true);
            sprite.flipX = false;

        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.left * velocity * Time.deltaTime);
            animator.SetBool("andar", true);
            sprite.flipX = true;

        } else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.up * velocity * Time.deltaTime);
            animator.SetBool("andar", true);

        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.down * velocity * Time.deltaTime);
            animator.SetBool("andar", true);

        } else {
            animator.SetBool("andar", false);
        }

        if (Input.GetKeyDown(KeyCode.R) && isReading) {
            Time.timeScale = 1;
            isReading = false;
            canvasPages.gameObject.SetActive(false);
        }
    }

    private void AddItem(GameObject addItem)
    {
        for (int i = 0; i <= itens.Length; i++)
        {
            if (itens[i] == null)
            {
                itens[i] = addItem.gameObject;
                imageItem[i].sprite = addItem.GetComponent<SpriteRenderer>().sprite;
                imageItem[i].enabled = true;
                return;
            }
        }
    }

    private void RemoveItem(GameObject removeItem) {

        for (int i = 0; i < itens.Length; i++)
        {
            if (itens[i] == removeItem)
            {
                itens[i] = null;
                imageItem[i].sprite = null;
                imageItem[i].enabled = false;
                return;
            }
        }
    }

    private void leaveObject(int index)
    {
        itens[index].SetActive(false);
        itens[index].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void verifyInventory(GameObject gameObject)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            verifyLowerPoint(gameObject, 0);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            verifyLowerPoint(gameObject, 1);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            verifyLowerPoint(gameObject, 2);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            verifyLowerPoint(gameObject, 3);
        }
    }

    private void verifyLowerPoint(GameObject gameObject, int indice)
    {

        switch (gameObject.name)
        {
            case "descarga_armario":
                if (itens[indice].name == "calça" || itens[indice].name == "camisa1" || itens[indice].name == "camisa2")
                {
                    leaveObject(indice);
                    RemoveItem(itens[indice]);
                }
                break;

            case "descarga_pia":
                if (itens[indice].name == "pratos_sujos")
                {
                    leaveObject(indice);
                    RemoveItem(itens[indice]);
                }
                break;

            case "descarga_lixo":
                if (itens[indice].name == "latas" || itens[indice].name == "racao")
                {
                    leaveObject(indice);
                    RemoveItem(itens[indice]);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "testeLayer" || collision.gameObject.name == "layerSala" ||
            collision.gameObject.name == "layerCozinha") {
            sprite.sortingLayerName = "Moveis";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "item":
                if (Input.GetKeyDown(KeyCode.P))
                {
                    AddItem(collision.gameObject);
                    collision.gameObject.SetActive(false);
                    //verify_item(collision.gameObject);
                    //pegou_item = true;
                }
                break;

            case "descarga":
                verifyInventory(collision.gameObject);
                break;

            case "diario":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Time.timeScale = 0;
                    isReading = true;
                    canvasPages.gameObject.SetActive(true);
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name == "layerSala") {
            sprite.sortingLayerName = "Default";
        }
    }
}
