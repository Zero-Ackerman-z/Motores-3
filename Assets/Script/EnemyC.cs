using UnityEngine;

public class EnemyC : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float visionRange = 5f; // Alcance de visión del enemigo.
    public Transform player;
    public LayerMask playerLayer; // Layer del jugador (asignado en el Inspector).
    public dañoandvida disminuir;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Inicializa el componente Rigidbody2D.
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("No se ha asignado el objeto del jugador en el Inspector del enemigo.");
            return;
        }

        // Calcula la dirección hacia el jugador.
        Vector2 directionToPlayer = player.position - transform.position;

        // Calcula la distancia al jugador
        float distanceToPlayer = directionToPlayer.x * directionToPlayer.x + directionToPlayer.y * directionToPlayer.y;

        // Si el jugador está dentro del alcance de visión, mueve al enemigo hacia el jugador.
        if (distanceToPlayer <= visionRange * visionRange)
        {
            // Normaliza la dirección para mantener una velocidad constante.
            Vector2 moveDirection = directionToPlayer.normalized;

            // Mueve al enemigo hacia el jugador.
            Vector3 newPosition = transform.position + new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Verifica si la colisión es con el jugador.
        if (collision.gameObject.layer == playerLayer)
        {
            disminuir.DisminucionLife();

            // Detén el movimiento al chocar con el jugador.
            rb.velocity = rb.velocity * 0.0f;

        }
    }
}
