using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaRespawnYGameOver : MonoBehaviour
{
    public GameObject player;                 // Referencia al jugador
    public GameObject areaRespawn;            // Círculo visible
    public float radius = 3f;                 // Radio de clic válido

    public bool isPaused = false;            // Si está esperando clic para respawn

    private Player playerScript;              // Referencia al script del jugador
    private Rigidbody2D rb;                   // Rigidbody del jugador
    private float gravedadOriginal;           // Para restaurar la gravedad al reiniciar
    public LayerMask suelo;

    public AudioSource audioSource;
    public Slider slider;

    void Start()
    {
        slider.value = FindObjectOfType<NivelesCompletados>().volumenMusica;

        areaRespawn.SetActive(false);         // Ocultamos el área al inicio
        playerScript = player.GetComponent<Player>();
        rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            gravedadOriginal = rb.gravityScale; // Guardamos la gravedad original
        }
    }

    public void TriggerGameOver()
    {
        isPaused = true;
        // Activamos el área de respawn
        areaRespawn.transform.position = player.transform.position;
        areaRespawn.transform.localScale = new Vector3(radius * 2, radius * 2, 1);
        areaRespawn.SetActive(true);
        // Desactivamos el movimiento del jugador
        if (playerScript != null)
        {
            playerScript.puedeMoverse = false;
        }
        // Congelamos el Rigidbody2D del jugador
        if (rb != null)
        {
            rb.velocity = Vector2.zero;         // Paramos el movimiento
            rb.gravityScale = 0f;               // Congelamos la caída
            rb.bodyType = RigidbodyType2D.Kinematic; // Congelamos físicas (opcional y más seguro)
        }
    }

    void Update()
    {
        //Si no está en pausa, no hacemos nada
        if (!isPaused) return;
        //Si clicamos con el botón izquierdo del ratón y estamos en el área de respawn
        if (Input.GetMouseButtonDown(0))
        {
            // Convertimos la posición del ratón a coordenadas del mundo
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0; //Nos aseguramos de que la z sea 0 para 2D
            // Comprobamos la distancia entre el ratón y el jugador
            float distance = Vector2.Distance(mouseWorld, player.transform.position);
            //Si la distancia es menor o igual al radio, reiniciamos el juego
            if (distance <= radius)
            {
                Collider2D hit = Physics2D.OverlapPoint(mouseWorld, suelo);
                if (hit == null) // Si no hay colisión, está libre
                {
                    RestartGame(mouseWorld);
                }
                
            }
        }
    }
    // Reiniciamos el juego y movemos al jugador a la nueva posición
    void RestartGame(Vector3 newPosition)
    {
        isPaused = false;
        // Movemos al jugador a la nueva posición
        player.transform.position = newPosition;
        areaRespawn.SetActive(false);
        // Restauramos el estado del jugador y las físicas
        if (playerScript != null)
        {
            playerScript.puedeMoverse = true;
            playerScript.playerSprite.SetActive(true);
        }
        // Restauramos la gravedad y las físicas del Rigidbody2D
        if (rb != null)
        {
            rb.gravityScale = gravedadOriginal;        // Restauramos la gravedad
            rb.bodyType = RigidbodyType2D.Dynamic;     // Restauramos las físicas normales
        }
    }

    public void SliderVolumen()
    {
        FindObjectOfType<NivelesCompletados>().volumenMusica = slider.value;
    }

}
