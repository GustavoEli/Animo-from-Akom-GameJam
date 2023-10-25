using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Scene : MonoBehaviour
{
    public GameObject canvas_menu;
    public GameObject canvas_creditos;
    public GameObject canvas_tutorial;

    public void Iniciar_jogo() {
        SceneManager.LoadScene(1);
    }

    public void creditos() {
        canvas_creditos.gameObject.SetActive(true);
        canvas_menu.gameObject.SetActive(false);
    }

    public void cred_para_menu() {
        canvas_menu.gameObject.SetActive(true);
        canvas_creditos.gameObject.SetActive(false);
    }

    public void tuto_para_menu() {
        canvas_tutorial.gameObject.SetActive(false);
        canvas_menu.gameObject.SetActive(true);
    }

    public void creditos_voltar_Menu()
    {
        canvas_creditos.gameObject.SetActive(false);
        canvas_menu.gameObject.SetActive(true);
    }

    public void Sair_jogo() {
        Application.Quit();
    }

    //public void tutorial() {
    //    canvas_tutorial.gameObject.SetActive(true);
    //    canvas_menu.gameObject.SetActive(false);
    //}
}
