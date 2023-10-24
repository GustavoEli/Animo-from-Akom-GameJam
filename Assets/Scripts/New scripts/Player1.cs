 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] InventoryManagement inventory;
    GameObject[] itens = new GameObject[4];
    [SerializeField] GameObject pagesCanvas;

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
            pagesCanvas.SetActive(false);
        }
    }

    private void VerifyInventory(GameObject gameObject) {
        
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
            inventory.VerifyLowerPoint(gameObject, 0, itens);

        } else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
            inventory.VerifyLowerPoint(gameObject, 1, itens);

        } else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
            inventory.VerifyLowerPoint(gameObject, 2, itens);

        } else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
            inventory.VerifyLowerPoint(gameObject, 3, itens);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "testeLayer" || collision.gameObject.name == "layerSala" ||
            collision.gameObject.name == "layerCozinha") {
            sprite.sortingLayerName = "Moveis";
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        
        switch (collision.gameObject.tag) {
            case "item":
                if (Input.GetKeyDown(KeyCode.P)) {
                    inventory.AddItem(collision.gameObject, itens);
                    collision.gameObject.SetActive(false);
                }
                break;

            case "descarga":
                VerifyInventory(collision.gameObject);
                break;

            case "diario":
                if (Input.GetKeyDown(KeyCode.E)) {
                    Time.timeScale = 0;
                    isReading = true;
                    pagesCanvas.SetActive(true);
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
