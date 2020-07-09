using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject cocheGo;

    public float anguloDeGiro;
    public float velocidad;
    

    void Start()
    {
        //Busco la referencia por componente, busco el objeto que tenga el componente del tipo Coche
        cocheGo = GameObject.FindObjectOfType<Coche>().gameObject;


    }

    
    void Update()
    {
        float giroEnZ = 0;

        //defino como lo voy a mover 
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);

        giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;

        //Transformo los valores decimales en angulos, El quaternion Euler hace que todos los valores que yo le pase los transforma en angulos
        cocheGo.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);


        
    }
}
