using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoMenuInicial : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider, sonidos;
    private void Start()
    {
        slider.value = FindObjectOfType<NivelesCompletados>().volumenMusica;
        sonidos.value = FindObjectOfType<NivelesCompletados>().volumenSonidos;
    }
    void Update()
    {
        audioSource.volume = FindObjectOfType<NivelesCompletados>().volumenMusica;
    }
    public void SliderVolumen()
    {
        FindObjectOfType<NivelesCompletados>().volumenMusica = slider.value;
    }
    public void SliderVolumenSonidos()
    {
        FindObjectOfType<NivelesCompletados>().volumenSonidos = sonidos.value;
    }
}
