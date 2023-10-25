using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condicaoVitoria : MonoBehaviour
{
    [SerializeField] GameObject [] objects = new GameObject[5];
    [SerializeField] GameObject canvas_victory;

    void Update() {
        if (!objects[0].activeInHierarchy && !objects[1].activeInHierarchy &&
            !objects[2].activeInHierarchy && !objects[3].activeInHierarchy &&
            !objects[4].activeInHierarchy) {
            canvas_victory.SetActive(true);
            Time.timeScale = 0;
        }
    }
        
}

