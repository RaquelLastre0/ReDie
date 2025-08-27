using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //audioSource.volume = 0f; 
            Destroy(gameObject);
        }
        else 
        {
            audioSource.volume = FindObjectOfType<NivelesCompletados>().volumenMusica; 
        }
    }
}
