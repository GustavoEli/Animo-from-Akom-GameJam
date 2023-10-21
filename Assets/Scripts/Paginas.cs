using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paginas : MonoBehaviour
{
    public Image spriteImage;
    public Sprite[] paginas = new Sprite[4];
    bool estaLendo;
    public GameObject paginas_object;
    public GameObject verificaPlayer;
    public int indice_paginas;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        spriteImage =  paginas_object.GetComponent<Image>();

        indice_paginas = 0;

        player = verificaPlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //estaLendo = verificaPlayer.GetComponent<Player>().estaLendo;
        estaLendo = player.estaLendo;

        if (estaLendo) {
            spriteImage.sprite = paginas[indice_paginas];
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (indice_paginas > 0) {
                spriteImage.sprite = paginas[indice_paginas--];
            } else {
                indice_paginas = 0;
            }

        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (indice_paginas < 3) {
                spriteImage.sprite = paginas[indice_paginas++];
            } else {
                indice_paginas = 3;
            }
        }
    }
}
