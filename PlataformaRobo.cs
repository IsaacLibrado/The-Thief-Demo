using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase para la plataforma de robo que recibe las bolsas de dinero
/// </summary>
/// Version 1.0
/// Fecha de creación 12/02/22
/// Creador Isaac Librado
public class PlataformaRobo : MonoBehaviour {
    
    //para el control del UI
    public Text puntosTXT;
    public Text countdownTime;

    private float puntos;

    //Referencia a otros scripts para controlar el juego
    public MovJu jugador;
    public Timer timer;
    

    void Update()
    {
        //cuando el jugador gana
        if (puntos >=8)
        {
            //terminamos el juego
            timer.contando = false;
            jugador.terminado = true;
            jugador.ganador = true;

            //cambiamos el UI
            countdownTime.text = "¡Lo lograste!";
            countdownTime.color = Color.green;
        }
    }

    /// <summary>
    /// Metodo para detectar cuando un objeto sale del collider
    /// </summary>
    /// <param name="other">Objeto que sale del collider</param>
    /// Version 1.0
    /// Fecha de creación 12/02/22
    /// Creador Isaac Librado
    private void OnTriggerStay(Collider other)
    {
        //detecta que el objeto sea un objeto recogible
        if (other.gameObject.CompareTag("Objeto"))
        {
            //eliminamos el objeto
			other.gameObject.SetActive(false);

            //cambiamos el UI
            puntos++;
            puntosTXT.text = puntos.ToString();
		}
    }
}
