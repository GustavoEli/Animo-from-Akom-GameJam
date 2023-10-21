using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoors : MonoBehaviour
{
    [SerializeField] Vector3[] doorsPosition = new Vector3[6];
    [SerializeField] GameObject[] doors = new GameObject[6];
    void Start()
    {
        for (int i = 0; i < doorsPosition.Length; i++) {
            doorsPosition[i] = doors[i].gameObject.GetComponent<Vector3>();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {

            switch (this.gameObject.tag) {
                case "entra_quarto":
                    collision.gameObject.transform.position = new Vector3(doors[0].transform.position.x, doors[0].transform.position.y - 3, 0);
                    break;

                case "entra_banheiro":
                    collision.gameObject.transform.position = new Vector3(doors[1].transform.position.x, doors[1].transform.position.y - 4, 0);
                    break;

                case "entra_sala":
                    if (collision.gameObject.name == "quarto-sala") {
                        collision.gameObject.transform.position = new Vector3(doors[2].transform.position.x - 3, doors[2].transform.position.y - 6, 0);
                    } else if (collision.gameObject.name == "cozinha-sala") {
                        collision.gameObject.transform.position = new Vector3(doors[5].transform.position.x - 3, doors[5].transform.position.y - 6, 0);
                    } else {
                        collision.gameObject.transform.position = new Vector3(doors[3].transform.position.x - 3, doors[3].transform.position.y - 3, 0);
                    }
                    break;

                case "entra_cozinha":
                    collision.gameObject.transform.position = new Vector3(doors[4].transform.position.x - 3, doors[4].transform.position.y);
                    break;
            }
        }
    }
}
