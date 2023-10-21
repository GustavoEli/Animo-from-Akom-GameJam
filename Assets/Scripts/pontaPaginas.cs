using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontaPaginas : MonoBehaviour
{
    public Image ponta_esquerda, ponta_direita;
    public Sprite esquerda, direita;
    public GameObject pontaEsq, pontaDire;
    int indice_paginas;
    public GameObject diario;

    Paginas paginas;

    // Start is called before the first frame update
    void Start()
    {
        ponta_esquerda = pontaEsq.GetComponent<Image>();
        ponta_direita = pontaDire.GetComponent<Image>();

        ponta_esquerda.sprite = esquerda;
        ponta_direita.sprite = direita;

        paginas = diario.gameObject.GetComponent<Paginas>();
    }

    // Update is called once per frame
    void Update()
    {
        //indice_paginas = diario.gameObject.GetComponent<Paginas>().indice_paginas;
        indice_paginas = paginas.indice_paginas;
        verificaPaginas(indice_paginas);
    }

    public void verificaPaginas(int indices) {

        if (indice_paginas == 0) {
            ponta_esquerda.gameObject.SetActive(false);
            ponta_direita.gameObject.SetActive(true);

        } else if (indice_paginas == 1 || indice_paginas == 2) {
            ponta_esquerda.gameObject.SetActive(true);
            ponta_direita.gameObject.SetActive(true);

        } else if(indice_paginas == 3) {
            ponta_esquerda.gameObject.SetActive(true);
            ponta_direita.gameObject.SetActive(false);
        }
    }
}
