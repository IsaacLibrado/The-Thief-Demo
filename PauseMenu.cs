using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase para controlar el menú de pausa
/// </summary>
/// Version 1.0
/// Fecha de creación 13/02/22
/// Creador Isaac Librado
public class PauseMenu : MonoBehaviour {

    //para validar si el juego está pausado
	public static bool GameIsPaused = false;

    //Para el UI del menu de pausa
    public GameObject pauseMenuUI;

	void Update()
    {
        //validamos si el jugador presiona la tecla de pausa
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            //si está pausado lo regresamos y si no, lo pausamos
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    /// <summary>
    /// Metodo para regresar al juego
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 13/02/22
    /// Creador Isaac Librado
    public void Resume()
    {
        //bloqueamos el mouse
        Cursor.lockState = CursorLockMode.Locked;

        //desactivamos el UI
        pauseMenuUI.SetActive(false);

        //regresamos al juego
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// <summary>
    /// Metodo para pausar el juego
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 13/02/22
    /// Creador Isaac Librado
    public void Pause()
    {
        //permitimos al jugador ver su mouse
        Cursor.lockState = CursorLockMode.Confined;

        //mostramos el UI
        pauseMenuUI.SetActive(true);

        //pausamos el juego
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /// <summary>
    /// Metodo para salir del juego
    /// </summary>
    /// Version 1.0
    /// Fecha de creación 13/02/22
    /// Creador Isaac Librado
    public void QuitGame()
    {
        Application.Quit();
    }
}
