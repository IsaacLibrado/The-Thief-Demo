using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase para permitir al guardia atrapar al jugador
/// </summary>
/// Versión 1.0
/// Fecha de creación 12/02/22
/// Creador Isaac Librado
public class ManoGuardia : MonoBehaviour {

	//atributos para detectar al jugador
	public Transform objetivo;
	public Mano jugador;
	public MovJu jugadorMov;

	/// <summary>
	/// Metodo que detecta en el collider
	/// </summary>
	/// <param name="other">El collider del objeto que entra al collider</param>
	/// Version 1.0
	/// Fecha de creación 12/02/22
	/// Creador Isaac Librado
	private void OnTriggerStay(Collider other)
    {
        //detecta que el objeto sea el jugador
        if (other.gameObject.CompareTag("Player"))
		{
			//si el jugador trae un objeto agarrado hacemos que lo tire
			if(jugador.pickedObject != null)
				jugador.TirarObjeto();

			//reiniciamos los valores de potencia y de posición
			jugadorMov.potencia = 100f;
			objetivo.position = new Vector3(-62, 1, -1);
			
		}
    }
}
