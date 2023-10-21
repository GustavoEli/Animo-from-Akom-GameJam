using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fades_player : MonoBehaviour
{   
    //int tempo_vidaPL;
    public Image image;
    private Color32 color;

    //int tempo;
    //bool estaPausado;
    public int animo;
    public int ganhaAnimo;
    public int perdeAnimo;
    string tipo_item;
    public GameObject confirma_Pause;
    public GameObject player_item;
    public GameObject canvas_gameover;

    //float contador;
    int verificador;
    int tempo_chegada;

    //float comeca_tempo;
    bool pegouItem;
    bool decair;
    float teste = 0;

    Player player;

    //public Animator animador;
    //public Slider slider;

    void Start()
    {
        tempo_chegada = 5;
        animo = 1;
        image = GetComponent<Image>();
        player = player_item.gameObject.GetComponent<Player>();
        //comeca_tempo = Time.time;

        #region comentarios
        //contador = 0;
        //tempo_vidaPL = 0;
        //tempo = 0;

        //Application.targetFrameRate = 30;

        //var color_temp = image.color;
        //color_temp.a = 50;
        //image.color = color_temp;
        // animador = GetComponent<Animator>();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //estaPausado = confirma_Pause.gameObject.GetComponent<Pause_System>().estaPausado;
        //pegouItem = player_item.gameObject.GetComponent<Player>().pegou_item;

        pegouItem = player.pegou_item;

        if (pegouItem) {
            tipo_item = player_item.gameObject.GetComponent<Player>().verifica_objeto;
        }
        //estaPausado = gameObject.GetComponent<Pause_System>().estaPausado;
        //tempo++;

        if (Time.timeScale == 0) {
            //float t = Time.time - comeca_tempo;
            teste += Time.deltaTime;
            verificador = Mathf.RoundToInt(teste % 60);


            if (verificador == tempo_chegada) {
                if (verificador == 60 && tempo_chegada == 60) {
                    tempo_chegada = 3;
                } else {
                    tempo_chegada = tempo_chegada + 3;
                    perder_Animo();
                }
            }
        }
        //Debug.Log(verificador + " a chegar: " + tempo_chegada + "  animo: " + animo + "esta Pausado? " + estaPausado);

        #region comentarios
        /*if (tempo <= 300 && !decair) {
            tempo++;

        } else if (tempo >= 300){
            decair = true;
        }

        if (decair && animo <= 200) {
            perder_Animo();
            tempo = 0;
            decair = false;
        }*/
        #endregion

        if (tipo_item == "livro" && pegouItem || tipo_item == "jam" && pegouItem) {
            ganhar_Animo();
            pegouItem = player_item.gameObject.GetComponent<Player>().pegou_item = false;
            //tempo = 0;
            //decair = false;
            //tipo_item = null;
        }

        if (animo >= 200){
            canvas_gameover.SetActive(true);
            Time.timeScale = 0;
        }

        maximo_bomAnimo();

        #region comentario
            //color.a = (byte)animo;
            //image.color = color;

            //color.a = (byte)tempo_vidaPL++;
            //tempo_vidaPL = tempo_vidaPL - 1;
            //animador.speed = tempo_vidaPL;
            #endregion
    }

    public void perder_Animo() {

        animo = animo + perdeAnimo;
        color.a = (byte)animo;
        image.color = color;
        //animo = (int)Time.deltaTime * animo;
        //tempo_vidaPL = tempo_vidaPL + animo;
    }

    public void ganhar_Animo() {

        animo = animo - ganhaAnimo;
        color.a = (byte)animo;
        image.color = color;
    }

    public void maximo_bomAnimo() {

        if (animo < 1){
            color.a = 0;
            image.color = color;
            animo = 0;
        }
    }

    /*public float contagem_tempo() {
        contador += Time.deltaTime * 1.0f;
        return contador;
    }*/

    //public void ganhar_Animo() {
    //    color.a = (byte)tempo_vidaPL--;
    //    image.color = color;
    //}
}