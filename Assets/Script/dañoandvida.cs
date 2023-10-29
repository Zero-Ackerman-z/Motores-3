using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoandvida : MonoBehaviour
{
    private float vida = 5.0f; // Cambiado a float para reflejar el tipo de datos.
    public life vida_canvas;
    public life vida_corazones;
    public LayerMask itemsLayer;

    private bool puedeRecibirDaño = true; // Variable para evitar daño repetido en una sola pulsación.

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vida_canvas.cambiovida((int)vida);

        // Verifica si la barra espaciadora está siendo presionada.
        if (Input.GetKeyDown(KeyCode.Space) && puedeRecibirDaño)
        {
            // Reduce la vida del jugador en 1 punto.
            vida -= 1;

            if (vida <= 0)
            {
                Die();
            }

            // Desactiva la capacidad de recibir daño hasta que se suelte la barra espaciadora.
            puedeRecibirDaño = false;
        }

        // Verifica si se ha soltado la barra espaciadora para volver a permitir el daño.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            puedeRecibirDaño = true;
        }

    }

    public  void Die()
    {
        // Realiza acciones de muerte aquí.
    }
    public void DisminucionLife()
    {
        if (vida < 5)
        {
            vida = vida - 1;
            vida_canvas.cambiovida((int)vida);
        }
    }
    public void Aumentolife()
    {
        if(vida < 5)
        {
            vida = vida + 1;
            vida_canvas.cambiovida((int)vida);
        }

    }
}
