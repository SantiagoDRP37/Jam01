using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject Hero;                 // Referencia al personaje principal
    private PlayerController_beta heroController;
    public float detectionDistance; // Distancia mínima para activar al enemigo
    public float speed;             // Velocidad de movimiento del enemigo
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;             // Referencia al Animator del enemigo

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        GameObject hero = GameObject.Find("Hero");
        if (hero != null)
        {
            heroController = hero.GetComponent<PlayerController_beta>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos la distancia entre el "Hero" y el "Ghost"
        float distanceToHero = Mathf.Abs(Hero.transform.position.x - transform.position.x);

        // Orientación enemy
        Vector3 direction = Hero.transform.position - transform.position;

        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Si la distancia es menor o igual a la de detección 
        if (distanceToHero <= detectionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, speed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el personaje principal (Hero)
        if (collision.gameObject.CompareTag("Hero") && heroController.isAttacking)
        {
            Animator.SetTrigger("Muere");

            StartCoroutine(HandleCollision());

        }
    }

    private IEnumerator HandleCollision()
    {
        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);  // Destruir al enemigo como ejemplo
    }

}
