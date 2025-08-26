using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("AudioSource");
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogWarning("No se encontr� AudioSource en el objeto con tag AudioSourceTag");
            }
        }
        else
        {
            Debug.LogWarning("No se encontr� ning�n objeto con tag AudioSourceTag");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip, 1f);
        }
    }
}
