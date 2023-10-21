using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_system : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public GameObject player;
    int animo_player;
    //int animo_teste;
    int animo_ruim, animo_bom;
    bool tocar;

    // Start is called before the first frame update
    void Start()
    {
        animo_ruim = Random.Range(0, 2);
        animo_bom = Random.Range(3,6);

        tocaSom();

        //audioSource.clip = audioClips[0];
        //audioSource.PlayOneShot(audioClips[0]);

        //audioClips[0] = (AudioClip)Resources.Load("Trilha sonora/mau_animo/M01-10");
        //audioSource.clip = audioClips[1];
        //audioSource.PlayOneShot(audioClips[1]);

    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.clip = audios[1];
        //audioSource.Play();
        //animo_player = pl_animo.gameObject.GetComponent<Fades_player>().animo;

        //animo_teste = player.gameObject.GetComponent<Fades_player>().animo;
        
        //Debug.Log(animo_teste);
        
    }

    public void tocaSom() {
        audioSource.clip = audioClips[animo_ruim];
        audioSource.PlayOneShot(audioClips[animo_ruim]);
    }
}
