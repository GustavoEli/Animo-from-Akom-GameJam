using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condicaoVitoria : MonoBehaviour
{
    public GameObject[] objetos = new GameObject[5];
    public GameObject canvas_vitoria;
    public Transform canvas;
    int conta = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas = canvas_vitoria.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < objetos.Length; i++) {
        //foreach(GameObject g in objetos) {
        //    if (!g.gameObject.activeInHierarchy) {
                    
        //        break;
        //        }
        //    }

        if (!objetos[0].activeInHierarchy &&
            !objetos[1].activeInHierarchy &&
            !objetos[2].activeInHierarchy &&
            !objetos[3].activeInHierarchy &&
            !objetos[4].activeInHierarchy) {
            canvas_vitoria.SetActive(true);
            Time.timeScale = 0;
        }
    }
        
}

