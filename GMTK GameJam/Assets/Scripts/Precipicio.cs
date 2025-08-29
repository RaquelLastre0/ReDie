using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Precipicio : MonoBehaviour
{
    public GameObject player;
    public GameObject posicionRespawn;
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("AudioSource");
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogWarning("No se encontró AudioSource en el objeto con tag AudioSourceTag");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con tag AudioSourceTag");
        }

        posicionRespawn.transform.position = player.transform.position;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            player.transform.position = posicionRespawn.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip, 0.7f);
            player.transform.position = posicionRespawn.transform.position;
            player.GetComponent<Player>().isJumping = false;
        }
    }
}
