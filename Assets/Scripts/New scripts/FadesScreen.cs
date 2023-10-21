using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadesScreen : MonoBehaviour
{
    [Header("Mood Properties")]
    [SerializeField] int moodPoints;
    [SerializeField] int gainMoodPoints;
    [SerializeField] int looseMoodPoints;
    [SerializeField] Image image;
    private Color32 color;

    [Header("Canvas Properties")]
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] Transform canvasVictory;

    [Header("Item Picked")]
    [SerializeField] Player playerItem;
    bool gotItem;
    string itemName;

    /*Ver se código é inutil
    int verificador;
    int tempo_chegada;
    float time = 0;*/

    void Start()
    {
        /*tempo_chegada = 5;
        moodPoints = 1;*/
        image = GetComponent<Image>();
    }

    void Update() {
        #region ver depois o codigo que possivelmente é inutil
        //if (Time.timeScale == 0) {
        //    time += Time.deltaTime;
        //    verificador = Mathf.RoundToInt(time % 60);

        //    if (verificador == tempo_chegada)
        //    {
        //        if (verificador == 60 && tempo_chegada == 60)
        //        {
        //            tempo_chegada = 3;
        //        }
        //        else
        //        {
        //            tempo_chegada = tempo_chegada + 3;
        //            loseMood();
        //        }
        //    }
        //}
        #endregion
        checkMood();
        verifyItem();
    }

    private void verifyItem() {
        gotItem = playerItem.pegou_item;

        if (gotItem) {
            itemName = playerItem.verifica_objeto;
        }
    }

    private void checkMood() {
        if (itemName == "livro" && gotItem || itemName == "jam" && gotItem) {
            gainMood();
            gotItem = playerItem.pegou_item = false;
        }

        if (moodPoints < 1) {
            color.a = 0;
            image.color = color;
            moodPoints = 0;
        }

        if (moodPoints >= 200) {
            canvasGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void loseMood() {
        moodPoints = moodPoints + looseMoodPoints;
        color.a = (byte)moodPoints;
        image.color = color;
    }

    private void gainMood() {
        moodPoints = moodPoints - gainMoodPoints;
        color.a = (byte)moodPoints;
        image.color = color;
    }
}
