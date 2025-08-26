using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorNiveles : MonoBehaviour
{
    public GameObject[] niveles;
    public GameObject derecha, izquierda, selector;
    int pos;

    public GameObject[] nivel;

    public int contador;

    //public NivelesCompletados contadorNiveles;

    void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        contador = NivelesCompletados.instance.contador;
        for (int i = 0; i < nivel.Length; i++)
        {
            if (contador >= i + 1)
            {
                nivel[i].gameObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                nivel[i].gameObject.GetComponent<Button>().interactable = false;
            }
        }
       
        if (SceneManager.GetActiveScene().buildIndex < 11)
        {
            pos = 0;
        }
        else if(SceneManager.GetActiveScene().buildIndex >10 && SceneManager.GetActiveScene().buildIndex < 21)
        {
            pos = 1;
        }
        else
        {
            pos = 2;
        }
        
        niveles[pos].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (pos == 0) 
        { 
            izquierda.SetActive(false);
        }
        else
        {
            izquierda.SetActive(true);
        }
        if (pos == niveles.Length - 1) 
        { 
            derecha.SetActive(false);
        }
        else
        {
            derecha.SetActive(true);
        }
    }

    public void Izquierda()
    {
        if (pos > 0)
        {
            niveles[pos].gameObject.SetActive(false);
            pos --;
            niveles[pos].gameObject.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Derecha()
    {
        if (pos < niveles.Length-1)
        {
            niveles[pos].gameObject.SetActive(false);
            pos++;
            niveles[pos].gameObject.SetActive(true);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void CambiarEscena(int nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
        selector.SetActive(false);
    }

    public void cerrarSelector()
    {
        selector.SetActive(false);
    }
}
