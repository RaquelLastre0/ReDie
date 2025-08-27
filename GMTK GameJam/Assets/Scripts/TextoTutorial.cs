using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextoTutorial : MonoBehaviour
{
    public AreaRespawnYGameOver gameOver;
    public GameObject texto;
    public TextMeshProUGUI textoNivel;
    int activado;
    public bool tutorial;
    public GameObject menuOpciones, sonidos, selector, botonMenu;

    // Start is called before the first frame update
    void Start()
    {
        textoNivel.text= "" + (SceneManager.GetActiveScene().buildIndex) + "/" + (SceneManager.sceneCountInBuildSettings - 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial)
        {
            if (gameOver.isPaused)
            { 
                texto.gameObject.SetActive(true);
                activado ++;
            }
            if (!gameOver.isPaused)
            {
                texto.gameObject.SetActive(false);
            }
        }
        if (menuOpciones.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void abrirOpciones()
    {
        botonMenu.SetActive(false);
        menuOpciones.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void cerrarOpciones()
    {
        botonMenu.SetActive(true);
        menuOpciones.SetActive(false);
    }

    public void abrirSonidos()
    {
        sonidos.SetActive(true);
        menuOpciones.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void cerrarSonidos()
    {
        sonidos.SetActive(false);
        menuOpciones.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void abrirSelector()
    {
        selector.SetActive(true);
        menuOpciones.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void cerrarSelector()
    {
        selector.SetActive(false);
        menuOpciones.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
