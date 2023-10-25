using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_System : MonoBehaviour
{
    [SerializeField] GameObject panel_pause;
    [SerializeField] GameObject Player_animo;
    bool isPaused = false;
    //int animo;
    //bool stop;

    public void Update() {
        //animo = Player_animo.GetComponent<Fades_player>().animo;

        //if (animo <= 200) {
        //    stop = false;
        //}else {
        //    stop = true;
        //}
        
        if (Input.GetKeyDown(KeyCode.Escape) /*&& stop == false*/) {
            if (isPaused) {
                Continue();
            } else {
                Pause();
            }
        }
    }

    private void Pause() {
        Time.timeScale = 0;
        panel_pause.SetActive(true);
        isPaused = true;
    }

    public void Continue() {
        Time.timeScale = 1;
        panel_pause.SetActive(false);
        isPaused = false;
    }

    public void Bt_Back() {
        Continue();
    }
    public void Bt_Leave() {
        Application.Quit();
    }
    //public void Bt_instrucao() { }
}
