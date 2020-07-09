using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    //Conecto el cronometro con el motro de carreteras
    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarreterasScript;
    
    public float tiempo;
    public float distancia;
    public Text txtDistancia;
    public Text txtTiempo;
    public Text txtDistanciaFinal;
   

  
    void Start()
    {
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarreterasGO.GetComponent<MotorCarreteras>();

        txtTiempo.text = "0:10";
        txtDistancia.text = "0";
        tiempo = 50;
    }

  
    void Update()
    {
        if(motorCarreterasScript.inicioJuego == true && motorCarreterasScript.finJuego == false)
        {
            CalculoTiempoDistancia();
        }
        
        if(tiempo <= 0 && motorCarreterasScript.finJuego == false)
        {
            motorCarreterasScript.finJuego = true;
            motorCarreterasScript.juegoTerminadoEstados();
            txtDistanciaFinal.text = ((int)distancia).ToString() + " mts";
        }
    }

    void CalculoTiempoDistancia()
    {

        distancia += Time.deltaTime * motorCarreterasScript.velocidad;
      
        txtDistancia.text = ((int)distancia).ToString();
        //El tiempo le resto el tiempo 
        tiempo -= Time.deltaTime;
        //el tiempo lo divido entre 60 y lo paso a entero para quitarle los decimales
        int minutos = (int)tiempo / 60;
        //Con el modulo le quito al tiempo los segundos
        int segundos = (int)tiempo % 60;
        //---------------------------------------------------------con Pad le pongo 0 y siempre empezará con 00
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');

    }
}
