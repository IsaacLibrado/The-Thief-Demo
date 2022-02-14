using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase para definir el cronometro de cuenta atrás
/// </summary>
/// Versión 1.0
/// Fecha de creación 12/02/22
/// Creador Isaac Librado 
public class Timer : MonoBehaviour {

	//Valores para el tiempo actual, el tiempo inicial y los minutos iniciales
	float currentTime=0f;
	float startingTime=59f;
	float minutes = 3;

	//para validar si se debe contar en el timer
	public bool contando;
	public MovJu jugador;

	//controlar el texto del UI
	public Text countdownTime;

	// Use this for initialization
	void Start () 
	{
		//iniciamos el conteo
		currentTime = startingTime;
		contando = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//solo si estamos contando hacemos estas acciones
		if (contando)
		{
			//Vamos restando un segundo cada update
			currentTime -= 1 * Time.deltaTime;
			
			//para evitar valores negativos
			if (currentTime < 0f)
			{
				minutes--;

				//para feedback al jugador de que el tiempo se acaba
				if (minutes < 1)
					countdownTime.color = Color.red;

				currentTime = 60f;
			}

			//para un mejor formato del texto
			if(currentTime <=9f)
				countdownTime.text = string.Format("0{0}:0{1}", minutes, currentTime.ToString("0"));
			else
				countdownTime.text = string.Format("0{0}:{1}", minutes, currentTime.ToString("0"));

			//cuando el tiempo se acaba terminamos el juego
			if (currentTime <= 0.1f && minutes <= 0f)
			{
				jugador.terminado = true;
				jugador.ganador = false;

				contando = false;
				countdownTime.text = "Se te acabó el tiempo.";
			}
		}
			
	}
}
