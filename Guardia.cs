using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Clase que controla el movimiento de los guardias enemigos
///Version 1.0
///Fecha de creación 10/02/22
///Creador Isaac Librado
public class Guardia : MonoBehaviour
{
    //velocidad del personaje
    public float velocidad = 7;

    //para el control de la ruta prestablecida
    private int cantidadPasos;
    private List<Vector3> ruta = new List<Vector3>();
    public int indice = 0;
    public int indRuta = 0;

    //para establecer su posición inicial en x
    public float xPos = 0;

    //Para seguir al jugador cuando se detecte
    private Vector3 objetivoMov;
    public Transform objetivo;

    //para controlar la luz de su lampara
    public Light luz;

    //para detectar al jugador
    public float rangoVision = 10;
    public float rangoFOV = 30;

    //para la persecución al jugador
    private Vector3 JugadorDesdeIA;
    float distanciaAJugador = 0;
    float angulo = 0;


    // Use this for initialization
    void Start()
    {
        //generamos las rutas e inicializams valores
        generarRutas();
        objetivoMov = ruta[indice];
        cantidadPasos = ruta.Count;
    }

    /// <summary>
    /// Metodo para generar las rutas del enemigos
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 10/02/22
    /// Creador Isaac Librado
    void generarRutas()
    {
        if (indRuta == 0)
        {
            // Inicializamos la lista de lugares que forman la ruta
            ruta.Add(new Vector3(xPos, 0.69f, 30));
            ruta.Add(new Vector3(xPos, 0.69f, -30));
        }
        else if (indRuta == 1)
        {
            ruta.Add(new Vector3(-30, 0.69f, 30));
            ruta.Add(new Vector3(30, 0.69f, 30));
            ruta.Add(new Vector3(30, 0.69f, -30));
            ruta.Add(new Vector3(-30, 0.69f, -30));
            ruta.Add(new Vector3(0, 0.69f, 0));
            ruta.Add(new Vector3(-30, 0.69f, 30));
            ruta.Add(new Vector3(30, 0.69f, 30));
            ruta.Add(new Vector3(0, 0.69f, 0));
            ruta.Add(new Vector3(30, 0.69f, -30));
            ruta.Add(new Vector3(-30, 0.69f, -30));
        }
        else if (indRuta == 2)
        {
            ruta.Add(new Vector3(-30, 0.69f, 30));
            ruta.Add(new Vector3(30, 0.69f, 30));
            ruta.Add(new Vector3(0, 0.69f, -30));
            ruta.Add(new Vector3(0, 0.69f, 30));
            ruta.Add(new Vector3(-30, 0.69f, 30));
            ruta.Add(new Vector3(30, 0.69f, 30));
            ruta.Add(new Vector3(30, 0.69f, -30));
            ruta.Add(new Vector3(0, 0.69f, 0));
            ruta.Add(new Vector3(-30, 0.69f, -30));
        }

    }

    // Update is called once per frame
    void Update()
    {

        bool visto = false;

        // Calculamos la distancia cuadrada
        distanciaAJugador = Vector3.SqrMagnitude(transform.position - objetivo.position);

        // Verificamos si esta en el rango de vision
        if (distanciaAJugador <= (rangoVision * rangoVision))
        {
            // Vector de la IA al personaje
            JugadorDesdeIA = objetivo.position - transform.position;

            // Calculamos el angulo
            angulo = Vector3.Angle(transform.forward, JugadorDesdeIA);

            // Verificamos si esta en el angulo de vision
            if (angulo <= rangoFOV && objetivo.position.x>-35f)
            {
                visto = true;
            }
        }

        //si vemos al jugador lo perseguimos, si no seguimos la ruta
        if (visto)
        {
            velocidad = 12;
            transform.LookAt(objetivo);

            //cambiamos el color para darle feedback al jugador
            luz.color = Color.red;
        }
        else
        {
            luz.color = Color.white;

            // Verificamos si hemos llegado a un punto de la ruta
            if ((transform.position - ruta[indice]).magnitude < 1f)
            {
                indice++;
                if (indice >= cantidadPasos)
                    indice = 0;

                objetivoMov = ruta[indice];
            }

            transform.LookAt(objetivoMov);
        }

        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

    }
}
