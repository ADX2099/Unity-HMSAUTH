using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarreterasScript;
    public Sprite[] Numeros;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorCocheGO;
    public GameObject cocheGo;

    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();
    }


    void InicioComponentes()
    {
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarreterasGO.GetComponent<MotorCarreteras>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        cocheGo = GameObject.Find("Coche");
        controladorCocheGO = GameObject.Find("ControladorCoche");
        InicioCuentaAtras();


    }



    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());

    }

    //Ahora hago una corutina para hacer el contando
    IEnumerator Contando()
    {
        //Ejecuta el sonido que tiene el controlador coche
        controladorCocheGO.GetComponent<AudioSource>().Play();
        //Espera dos segundos 
        yield return new WaitForSeconds(2);

        //Cambia la imagen 
        contadorNumerosComp.sprite = Numeros[1];
        //Ejecuta el sonido del game object en el que estas
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = Numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        //Coloca la imagen numero 3 cambia a GO
        contadorNumerosComp.sprite = Numeros[3];
        //Inicia el juego
        motorCarreterasScript.inicioJuego = true;
        //Ejecuto el audio que tiene el componente contadosr numeros GO
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        //Cambia el sonido por el boton funcionando
        cocheGo.GetComponent<AudioSource>().Play();
        //espera dos segundos
        yield return new WaitForSeconds(2);
        //Apaga el cartel
        contadorNumerosGO.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
