using UnityEngine;

/// <summary>
/// Controla el movimiento del jugador, incluyendo desplazamiento horizontal y salto
/// </summary>
public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float fuerzaSalto = 7f; // Fuerza del salto
    public float movimiento = 0f;
    
    private bool enSuelo = true; // Variable para verificar si está en el suelo
    private Rigidbody2D rb;
    
    [SerializeField] ParticleSystem particulas; // Partícula de salto
    private AudioSource efectoSonido; // Componente de audio para reproducir sonidos


    /// <summary>
    /// Inicializa los componentes necesarios al inicio del juego
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        efectoSonido = GetComponent<AudioSource>(); // Obtiene el componente de audio del GameObject
    }

    /// <summary>
    /// Actualiza el movimiento del jugador cada frame
    /// </summary>
    void Update()
    {
        movimiento = Input.GetAxis("Horizontal"); // Obtiene el input horizontal (A/D o flechas izquierda/derecha)
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y); // Aplica la velocidad al Rigidbody2D

        // Función de salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false; // El jugador ya no está en el suelo
        }
    }

    /// <summary>
    /// Maneja las colisiones con otros objetos
    /// </summary>
    /// <param name="objeto">El objeto con el que se ha colisionado</param>
    void OnCollisionEnter2D(Collision2D objeto)
    {
        if (objeto.gameObject.tag == "Pelota")
        {
            particulas.Play();
            efectoSonido.Play();// Reproduce las partículas al colisionar con un objeto que tenga la etiqueta "Pelota"
        }
        
        // Verificar si el jugador toca el suelo - usar solo un tag
        if (objeto.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true; // El jugador está en el suelo y puede saltar
        }
    }
}