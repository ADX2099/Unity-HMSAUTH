using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    //Almacenamos los mp3 con Audio clips

    public AudioClip[] fxs;
    AudioSource audioS;
    
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    //0 choque

    public void FXSonidoChoque()
    {
        audioS.clip = fxs[0];
        audioS.Play();
    }


    //1 Music game
    public void FXMusic()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }


    
}
