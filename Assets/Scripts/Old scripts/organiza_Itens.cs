using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class organiza_Itens : MonoBehaviour
{
    public SpriteRenderer image;
    public Sprite sprite;
    public GameObject player;
    public GameObject objeto_troca;
    Collider colider;
    public GameObject animo;
    Fades_player mudar_animo;

    // Start is called before the first frame update
    void Start()
    {
        image = objeto_troca.GetComponent<SpriteRenderer>();
        mudar_animo = animo.GetComponent<Fades_player>();
        colider = GetComponent<Collider>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.P))
        {
            image.sprite = sprite;
            mudar_animo.ganhar_Animo();
            colider.enabled = false;

        }
    }
}
