using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_sons : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public void btSom_iniciar() {
        audioSource.clip = audioClips[0];
        audioSource.PlayOneShot(audioClips[0]);
    }
    public void btSom_intruçoes() {
        audioSource.clip = audioClips[1];
        audioSource.PlayOneShot(audioClips[1]);
    }

    public void btSom_sair() {
        audioSource.clip = audioClips[2];
        audioSource.PlayOneShot(audioClips[2]);
    }
}
