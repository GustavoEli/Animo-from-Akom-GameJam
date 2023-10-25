using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta_comodo : MonoBehaviour
{
    public GameObject player;
    public Vector3 [] posicao_portas = new Vector3 [6];
    public GameObject [] portas = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < posicao_portas.Length; i++) {

            posicao_portas[i] = portas[i].gameObject.transform.position; 
            //posicao_portas[i] = portas[i].gameObject.GetComponent<Vector3>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {

            Debug.Log("colidiu");

            switch (this.gameObject.tag) {
                case "entra_quarto":
                    collision.gameObject.transform.position = new Vector3(portas[0].transform.position.x, portas[0].transform.position.y - 3, 0);
                    break;

                case "entra_banheiro":
                    collision.gameObject.transform.position = new Vector3(portas[1].transform.position.x, portas[1].transform.position.y - 4, 0);
                    break;

                case "entra_sala":
                    if (collision.gameObject.name == "quarto-sala")
                    {
                        collision.gameObject.transform.position = new Vector3(portas[2].transform.position.x - 3, portas[2].transform.position.y - 6, 0);
                    }
                    else if (collision.gameObject.name == "cozinha-sala") {
                        collision.gameObject.transform.position = new Vector3(portas[5].transform.position.x - 3, portas[5].transform.position.y - 6, 0);
                    }
                    else
                    {
                        collision.gameObject.transform.position = new Vector3(portas[3].transform.position.x - 3, portas[3].transform.position.y - 3, 0);
                    }
                    break;

                case "entra_cozinha":
                    collision.gameObject.transform.position = new Vector3(portas[4].transform.position.x - 3, portas[4].transform.position.y);
                    break;
            }
        }
    }

}
