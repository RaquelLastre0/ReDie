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

    public GameObject imagen, imegensSinLetras, elegirNivel, sliderVolumen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return))
        {
            Jugar();
        }
        if (elegirNivel.gameObject.activeSelf)
        {
            imagen.SetActive(false);
            imegensSinLetras.SetActive(true);
            menuPrincipal.SetActive(false);
            sliderVolumen.SetActive(false);
        }
        else
        {
            imagen.SetActive(true);
            imegensSinLetras.SetActive(false);
            menuPrincipal.SetActive(true);
            sliderVolumen.SetActive(true);
        }
    }
    //Cargar Juego
    public void Jugar()
    {
        elegirNivel.SetActive(true);

        //SceneManager.LoadScene(1);
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
}
