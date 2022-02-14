using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Clase para controlar el menu principal
/// </summary>
/// Version 1.0
/// Fecha de creación 13/02/22
/// Creador Isaac Librado
public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Metodo para empezar el juego
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 13/02/22
    /// Creador Isaac Librado
    public void PlayGame()
    {
        //para indicarle al admin de escenas que continue al siguiente
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Metodo para terminar el juego
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 13/02/22
    /// Creador Isaac Librado
    public void QuitGame()
    {
        Application.Quit();
    }
}
