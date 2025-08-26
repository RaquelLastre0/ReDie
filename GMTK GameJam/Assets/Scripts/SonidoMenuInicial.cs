using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoMenuInicial : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    private void Start()
    {
        slider.value = FindObjectOfType<NivelesCompletados>().volumenMusica;
    }
    void Update()
    {
        audioSource.volume = FindObjectOfType<NivelesCompletados>().volumenMusica;
    }
    public void SliderVolumen()
    {
        FindObjectOfType<NivelesCompletados>().volumenMusica = slider.value;
    }
}
