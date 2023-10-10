using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5f;

    [Header("Raycast Properties")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayDistance = 0.2f; 
    [SerializeField] private Color rayDebugColor = Color.red;

    private Vector2 movement; 
    private Rigidbody2D myRB; 
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); 

        canJump = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayers); 

        Debug.DrawRay(transform.position, Vector2.down * rayDistance, rayDebugColor); 
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce); 
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2(movement.x * speed, myRB.velocity.y); 

        
    }
    public void PlayerDamaged()
    {

    }
}

    


