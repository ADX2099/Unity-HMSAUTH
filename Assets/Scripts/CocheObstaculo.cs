using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject cronometrgoGO;
    public Cronometro cronometroScript;

    public GameObject audioFXGO;
    public AudioFX audioFXScript;

    private void Start()
    {
        cronometrgoGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometrgoGO.GetComponent<Cronometro>();

        audioFXGO = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coche>() != null){

            audioFXScript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Destroy(this.gameObject);
        
        }
    }
}
