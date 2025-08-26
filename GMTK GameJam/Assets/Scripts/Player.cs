using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col; // Agrega el collider
    public float speed = 5f;
    public float jumpForce = 10f;
    [SerializeField] private bool isJumping;
    [SerializeField] public bool puedeMoverse = true;
    [SerializeField] private PhysicsMaterial2D noFrictionMaterial;   // Fricción 0
    [SerializeField] private PhysicsMaterial2D normalMaterial;       // Fricción normal

    public Animator animator;
    public AreaRespawnYGameOver gameOver;

    public ParticleSystem particulaMuerte;
    public GameObject playerSprite;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public Animator animatorTransicion;

    public NivelesCompletados niveles;


    //La parte de friccion esta hecha para evitar que el personaje se quede atascado en paredes
    void Start()
    {
        niveles = FindObjectOfType<NivelesCompletados>();

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

        rb = GetComponent<Rigidbody2D>(); //Asigna el Rigidbody2D
        col = GetComponent<Collider2D>(); // Asigna el collider
        animator = GetComponent<Animator>();
        col.sharedMaterial = normalMaterial; //Asigna el material de fricción normal al collider

    }

    void Update()
    {
        audioSource.volume = FindAnyObjectByType<NivelesCompletados>().volumenMusica;
        Movimiento();
    }

    void Movimiento()
    {
        // Si el jugador no puede moverse, no hacemos nada
        if (!puedeMoverse) return;
        // Obtenemos la velocidad actual del Rigidbody2D
        Vector2 movimiento = rb.velocity;

        // Comprobamos las teclas de movimiento
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movimiento.x = -speed;
            
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movimiento.x = speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            movimiento.x = 0f; // Detener el movimiento si no se pulsa ninguna tecla
            
        }

        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKey(KeyCode.UpArrow)) && !isJumping)
        {
            movimiento.y = jumpForce;
            isJumping = true;
            animator.SetBool("Jump", true);
            col.sharedMaterial = noFrictionMaterial; // Sin fricción al saltar para que no se quede atascado
        }

        rb.velocity = movimiento;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            //Comprobar si el contacto es por abajo
            foreach (ContactPoint2D contacto in collision.contacts)
            {
                // Solo restaurar fricción si tocamos el suelo por abajo
                if (contacto.normal.y > 0.5f)
                {
                    isJumping = false;
                    animator.SetBool("Jump", false);
                    col.sharedMaterial = normalMaterial;
                    break; // Solo necesitamos un contacto válido
                }
            }
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            audioSource.PlayOneShot(audioClip);
            particulaMuerte.Play();
            gameOver.TriggerGameOver();
            playerSprite.SetActive(false);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meta"))
        {
            animatorTransicion.SetTrigger("TranSalir");
            StartCoroutine(cambiarEscena());
           
        }
    }
    IEnumerator cambiarEscena()
    {
        //animatorTransicion.SetBool("Salir",true);
        yield return new WaitForSeconds(0.5f);
        int escenaActual = SceneManager.GetActiveScene().buildIndex; //Recoje el índice de la escena actual
        niveles.Sumar();
        SceneManager.LoadScene(escenaActual + 1); //Pone la escena siguiente
    }
}
