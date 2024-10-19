using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_beta : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public Vector3 initialPosition;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.4f))
        {
            Grounded = true;
            Animator.SetBool("Jumping", false);
        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        if (transform.position.y < -5.0f)
        {
            transform.position = initialPosition;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Animator.SetTrigger("Attack");
        }

    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);

        Animator.SetBool("Jumping", true);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

   
}
