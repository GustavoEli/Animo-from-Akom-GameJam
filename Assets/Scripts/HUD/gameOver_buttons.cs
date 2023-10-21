using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver_buttons : MonoBehaviour
{
    public void bt_voltarMenu() {
        SceneManager.LoadScene(0);
    }
}
