using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{

    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;
    public float velocidad;
    public bool inicioJuego;
    public bool finJuego;
    int contadorCalles = 0;
    int numeroSelectorCalles;

    public GameObject calleAnterior;
    public GameObject calleNueva;
    public float tamañoCalle;
    public float tamañoPieza;

    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;
    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject cocheGo;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public GameObject bgFinalGo;

    void Start()
    {
        InicioJuego();
    }
    //----------------------------------------------------------------------------------------------
    //Funcion de inicializacion del juego 
    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("Main Camera");
        mCamComp = mCamGo.GetComponent<Camera>();
        bgFinalGo = GameObject.Find("PanelGameOver");
        bgFinalGo.SetActive(false);

        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

        cocheGo = GameObject.FindObjectOfType<Coche>().gameObject;
        velocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
       
    }
    //----------------------------------------------------------------------------------------------
    public void juegoTerminadoEstados()
    {
        cocheGo.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        bgFinalGo.SetActive(true);
    }
    //----------------------------------------------------------------------------------------------
    void velocidadMotorCarretera()
    {
        velocidad = 18;
    }
    //----------------------------------------------------------------------------------------------
    void BuscoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        //Iteracion para obtener las calles
        for (int i = 0; i < contenedorCallesArray.Length; i++)
        {
            //este game objecti hazlo hijo en la jerarquia
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform;
            //Apago el game object
            contenedorCallesArray[i].gameObject.SetActive(false);
            //Cambia el nombre
            contenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }
        //Una vez encontrada la calle ahora la creo 
        crearCalles();
    }
    //----------------------------------------------------------------------------------------------
    void crearCalles()
    {
        //lo hago crecer para ir identificando que se va creciendo
        contadorCalles++;
        //creo una calle aleatoria con el rango de 0 al largo del array
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);
        //Creo la instanci de la calle 
        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        //
        Calle.SetActive(true);
        Calle.name = "Calle" + contadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();

    }
    //----------------------------------------------------------------------------------------------
    void midoCalle()
    {
        //Entro a la calle anterior y cuento los hios que tiene 
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            //Solamente entro si es que el gameobject contiene el componente pieza
            if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                //Esta es la mejor forma de acceder que es por componente porque asi me garantiza que siempre vo a encontrar ese componente y no va a cambiar de nombre
                //Solo no lo va a encontrar y no me tira error
                //Creo una variable termporar para almacenar el tamaño del sprite renderer, 
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                Debug.Log("El tamaño de la pieza:" + tamañoPieza);
                Debug.Log("El tamaño calle inicial:" + tamañoCalle); 
                tamañoCalle = tamañoCalle + tamañoPieza;
                Debug.Log("El tamaño calle final:" + tamañoCalle);

            }
            
        }
    }
    //----------------------------------------------------------------------------------------------
    void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        midoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x,
            calleAnterior.transform.position.y + tamañoCalle, 0);
        salioDePantalla = false;
            
    }
    //----------------------------------------------------------------------------------------------
    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, mCamComp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }
    //----------------------------------------------------------------------------------------------
    void Update()
    {
        if(inicioJuego == true && finJuego == false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            if (calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruyoCalles();

            }
        }
        
       
    }
    //----------------------------------------------------------------------------------------------
    void DestruyoCalles()
    {
        Destroy(calleAnterior);
        tamañoCalle = 0;
        calleAnterior = null;
        crearCalles();
    }
    //----------------------------------------------------------------------------------------------


}
