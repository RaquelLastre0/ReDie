using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    //Plantilla para Menu
    //Objetos de la escena, para activarlos/desactivarlos cuando sea necesario
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject opciones;
    [SerializeField] private GameObject creditos;

    public GameObject imagen, imegenSinLetras, elegirNivel, sonidos, botonSelector, volumenes;

    private void Update()
    {
        if (elegirNivel.gameObject.activeSelf)
        {
            imagen.SetActive(false);
            imegenSinLetras.SetActive(true);
            botonSelector.SetActive(false);
            menuPrincipal.SetActive(false);
            sonidos.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                elegirNivel.SetActive(false);
            }
        }
        else if(volumenes.gameObject.activeSelf)
        {
            imagen.SetActive(false);
            imegenSinLetras.SetActive(true);
            botonSelector.SetActive(true);
            menuPrincipal.SetActive(true);
            sonidos.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            { 
                volumenes.SetActive(false);
            }
        }
        else
        {
            imagen.SetActive(true);
            imegenSinLetras.SetActive(false);
            botonSelector.SetActive(true);
            menuPrincipal.SetActive(true);
            sonidos.SetActive(true);
        }

        if (volumenes.gameObject.activeSelf)
        {
            botonSelector.SetActive(false);
            menuPrincipal.SetActive(false);
            sonidos.SetActive(false);
        }
    }
    //Cargar Juego
    public void AbrirSelector()
    {
        elegirNivel.SetActive(true);
    }

    public void CerrarSelector()
    {
        elegirNivel.SetActive(false);
    }

    //Salir del juego (de la aplicación)
    public void Salir()
    {
        Application.Quit();
    }
    //Esconde menuPrincipal para mostrar las opciones
    public void Opciones()
    {
        menuPrincipal.SetActive(false);
        opciones.SetActive(true);
    }
    //Lo mismo que el anterior, pero para mostrar créditos
    public void Creditos()
    {
        menuPrincipal.SetActive(false);
        creditos.SetActive(true);
    }

    public void VolverAlMenuPrincipal()
    {
        opciones.SetActive(false);
        creditos.SetActive(false);
        menuPrincipal.SetActive(true);
    }
    public void Jugar() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void elegirVolumen()
    {
        volumenes.SetActive(true);
    }
    public void cerrarVolumen()
    {
        volumenes.SetActive(false);
    }
}
