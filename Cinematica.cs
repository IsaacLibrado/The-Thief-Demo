using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase para controlar la cinematica inicial
/// </summary>
/// Version 1.0
/// Fecha de creación 13/02/22
/// Creador Isaac Librado
public class Cinematica : MonoBehaviour {

	//Atributos que controlan el UI y el sonido
	public GameObject textBox;
	public AudioSource encendido;

	// Use this for initialization
	void Start () {
		//iniciamos la corutina de secuncia
		StartCoroutine(Secuencia());
	}

	/// <summary>
	/// Corutina que se ejecuta y le regresa el control al juego mientras espera un tiempo
	/// </summary>
	/// <returns>la cantidad de tiempo a esperar</returns>
	/// Version 1.0
	/// Fecha de creación 13/02/22
	/// Creador Isaac Librado
	IEnumerator Secuencia()
    {
		//Para los textos de la cinamtica inicial
		yield return new WaitForSeconds(1);
		textBox.SetActive(true);
		yield return new WaitForSeconds(1);
		textBox.GetComponent<Text>().text = "Hemos apagado las luces para permitirte robar las bolsas";
		yield return new WaitForSeconds(3.5f);
		textBox.GetComponent<Text>().text = "No dejes que te atrapen";
		yield return new WaitForSeconds(3);
		encendido.Play();
		textBox.GetComponent<Text>().text = "Lleva las bolsas a la van antes de que se acabe el tiempo";
		yield return new WaitForSeconds(7);
		textBox.GetComponent<Text>().text = "";

		//al terminar la cinematica cambiamos a la siguiente escena
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
