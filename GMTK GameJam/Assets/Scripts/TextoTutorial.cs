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
    public GameObject selector;

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
    }

    public void abrirSelector()
    {
        selector.SetActive(true); 
        EventSystem.current.SetSelectedGameObject(null);
    }
}
