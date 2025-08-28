using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NivelesCompletados : MonoBehaviour
{
    public int contador = 1;
    public static NivelesCompletados instance;
    public float volumenMusica, volumenSonidos;

    //public Slider slider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Sumar();
    }

    public void Sumar()
    {
        if (SceneManager.GetActiveScene().buildIndex > contador)
        {
            contador = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
