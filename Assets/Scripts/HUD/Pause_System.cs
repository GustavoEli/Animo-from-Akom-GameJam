using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_System : MonoBehaviour
{
    public Transform panel_pause;
    public bool estaPausado = false;
    public GameObject Player_animo;
    int animo;
    bool parar;

    public void Update()
    {
        animo = Player_animo.GetComponent<Fades_player>().animo;

        if (animo <= 200)
        {
            parar = false;
        }else {
            parar = true;
        }
            if (Input.GetKeyDown(KeyCode.Escape) && parar == false)
            {

                if (estaPausado)
                {
                    continuar();
                }
                else
                {
                    Pausar();
                }
            }
    }

    public void Pausar() {
        Time.timeScale = 0;
        panel_pause.gameObject.SetActive(true);
        estaPausado = true;
    }

    public void continuar() {
        Time.timeScale = 1;
        panel_pause.gameObject.SetActive(false);
        estaPausado = false;
    }

    public void Bt_voltar() {
        continuar();
    }

    public void Bt_instrucao() { }

    public void Bt_sair() {
        Application.Quit();
    }
}
