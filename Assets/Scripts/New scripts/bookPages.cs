using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookPages : MonoBehaviour
{
    [Header("Pages Properties")]
    [SerializeField] Sprite[] pages = new Sprite[4];
    [SerializeField] Image spriteImage;
    [SerializeField] Player player;
    [SerializeField] Image leftPointImage, rightPointImage;
    [SerializeField] Sprite left, right;
    bool isReading;
    int pagesIndex = 0;

    //[SerializeField] GameObject pontaEsq, pontaDire;
    //[SerializeField] GameObject verificaPlayer;
    //[SerializeField] GameObject paginas_object;

    void Start() {

        leftPointImage = gameObject.GetComponent<Image>();
        rightPointImage = gameObject.GetComponent<Image>();
        leftPointImage.sprite = left;
        rightPointImage.sprite = right;

        /*spriteImage = paginas_object.GetComponent<Image>();
        player = verificaPlayer.GetComponent<Player>();*/
    }

    void Update() {
        MovePages();
        verificaPaginas();
    }

    private void MovePages() {
        isReading = player.estaLendo;

        if (isReading) {
            spriteImage.sprite = pages[pagesIndex];
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (pagesIndex > 0) {
                spriteImage.sprite = pages[pagesIndex--];
            } else {
                pagesIndex = 0;
            }

        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (pagesIndex < 3){
                spriteImage.sprite = pages[pagesIndex++];
            } else {
                pagesIndex = 3;
            }
        }
    }

    private void verificaPaginas() {

        if (pagesIndex == 0) {
            leftPointImage.gameObject.SetActive(false);
            rightPointImage.gameObject.SetActive(true);

        } else if (pagesIndex == 1 || pagesIndex == 2) {
            leftPointImage.gameObject.SetActive(true);
            rightPointImage.gameObject.SetActive(true);

        } else if (pagesIndex == 3) {
            leftPointImage.gameObject.SetActive(true);
            rightPointImage.gameObject.SetActive(false);
        }
    }
}
