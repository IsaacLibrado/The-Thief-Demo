using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase para controlar el recoger objetos
/// </summary>
/// Version 1.0
/// Fecha de creación 12/02/22
/// Creador Isaac Librado
public class Mano : MonoBehaviour {

    //game object para indicar dónde deberá estar el objeto
    public GameObject handPoint;

    //Script del jugador
    public MovJu jugador;

    //game object para almacenar el objeto tomado
    public GameObject pickedObject = null;

    //para indicar al jugador cuando puede recoger objetos
    public GameObject texto;


    // Update is called once per frame
    void Update()
    {

        //validamos si tenemos objetos en la mano
        if (pickedObject != null)
        {
            //cambiamos el texto de indicación
            texto.GetComponent<Text>().text = "Presiona Q para tirar";

            if (Input.GetKey("q"))
            {
                //suelta el objeto
                TirarObjeto();
                texto.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Metodo para tirar los objetos de la mano
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 12/02/22
    /// Creador Isaac Librado
    public void TirarObjeto()
    {
        //devolvemos las fisica del objeto a sus valores originales
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject.GetComponent<Collider>().enabled = true;

        //quitamos el objeto de la mano
        pickedObject.gameObject.transform.SetParent(null);

        // damos una fuerza para el lanzamiento del objeto
        pickedObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);

        //quitamos el objeto de la referencia e indicamos que el jugador ya no está agarrando
        pickedObject = null;
        jugador.agarrando = false;
    }

    /// <summary>
    /// Metodo para detectar cuando un objeto entra en el collider
    /// </summary>
    /// <param name="other">Objeto que entra en el collider</param>
    /// /// Version 1.0
    /// Fecha de creación 12/02/22
    /// Creador Isaac Librado
    private void OnTriggerStay(Collider other)
    {
        //detecta que el objeto sea un objeto recogible
        if (other.gameObject.CompareTag("Objeto"))
        {
            //cambiamos el 
            texto.SetActive(true);
            texto.GetComponent<Text>().text = "Presiona E para recoger";

            //valida si presionamos la tecla de interacción y no tenemos objeto en la mano
            if (Input.GetKey("e") && pickedObject == null)
            {
                //indicamos que el jugador está agarrando
                jugador.agarrando = true;

                //cambiamos las fisicas del objeto para evitar errores
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = false;

                //colocamos el objeto en la mano
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }

    /// <summary>
    /// Metodo para detectar cuando un objeto sale del collider
    /// </summary>
    /// <param name="other">Objeto que sale del collider</param>
    /// Version 1.0
    /// Fecha de creación 12/02/22
    /// Creador Isaac Librado
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Objeto"))
        {
            texto.SetActive(false);
        }  
    }
}
