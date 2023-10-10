using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntaje : MonoBehaviour
{
    private int score;
    public Text scoreText;

    // Capa que queremos detectar
    public LayerMask coinLayer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si el objeto colisionado está en la capa de monedas
        if (((1 << collision.gameObject.layer) & coinLayer) != 0)
        {
            score++;
            scoreText.text = ("Puntaje: " + score);
        }
    }
}
