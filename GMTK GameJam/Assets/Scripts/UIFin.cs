using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFin : MonoBehaviour
{
    public float timer;
    public GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            texto.SetActive(true);
        }
    }

    public void volverAlMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
