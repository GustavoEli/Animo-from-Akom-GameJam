using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    [Header("Mood Properties")]
    [SerializeField] int moodPoints;
    [SerializeField] int gainMoodPoints;
    [SerializeField] int looseMoodPoints;
    [SerializeField] Image image;
    private Color32 color;

    [Header("Canvas Properties")]
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasVictory;

    [Header("Item Picked")]
    [SerializeField] Player1 playerItem;
    GameObject[] objectsOnPlace = new GameObject[5];
    bool gotItem;
    string itemName;

    void Update()
    {
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
        WinCondition();
        CheckMood();
        VerifyItem();
    }

    private void VerifyItem() {
        gotItem = playerItem.gotItem;

        if (gotItem) {
            itemName = playerItem.verifyItem;
        }
    }

    private void CheckMood() {
        if (itemName == "livro" && gotItem || itemName == "jam" && gotItem) {
            GainMood();
            gotItem = playerItem.gotItem = false;
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

    private void LoseMood() {
        moodPoints = moodPoints + looseMoodPoints;
        color.a = (byte)moodPoints;
        image.color = color;
    }

    private void GainMood() {
        moodPoints = moodPoints - gainMoodPoints;
        color.a = (byte)moodPoints;
        image.color = color;
    }

    private void WinCondition() {
        if (!objectsOnPlace[0].activeInHierarchy && !objectsOnPlace[1].activeInHierarchy &&
            !objectsOnPlace[2].activeInHierarchy && !objectsOnPlace[3].activeInHierarchy &&
            !objectsOnPlace[4].activeInHierarchy) {
            canvasVictory.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
