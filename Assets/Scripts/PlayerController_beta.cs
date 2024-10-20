using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_beta : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public Vector3 initialPosition;
    public bool isAttacking=false;
    public CapsuleCollider2D capsuleCollider2D;
    public PolygonCollider2D PolygonCollider2D;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        capsuleCollider2D.enabled = true;
        PolygonCollider2D.enabled = false;

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
            isAttacking = true;
            capsuleCollider2D.enabled = false;
            PolygonCollider2D.enabled = true;
        }
        else
        {
            isAttacking = false;

            capsuleCollider2D.enabled = true;
            PolygonCollider2D.enabled = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colisionó es el enemigo (skeleton)
        if ((collision.gameObject.CompareTag("Skeleton") || collision.gameObject.CompareTag("Ghost")) && !PolygonCollider2D.enabled)
        {
            // Acción cuando el enemigo toca al personaje
            Animator.SetTrigger("Hurt");

            // Aquí puedes añadir lo que debería ocurrir: perder vida, cambiar de animación, etc.
        }

        // Verificca si colisiona con el suelo dañino
        if (collision.gameObject.CompareTag("Pain"))
        {
            Animator.SetTrigger("Hurt");
        }
    }

}
