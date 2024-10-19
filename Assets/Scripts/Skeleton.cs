using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrip : MonoBehaviour
{
    public GameObject Hero;                 // Referencia al personaje principal
    public float detectionDistance; // Distancia mínima para activar al enemigo
    public float speed;             // Velocidad de movimiento del enemigo
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;             // Referencia al Animator del enemigo

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos la distancia entre el "Hero" y el "Skeleton"
        float distanceToHero = Mathf.Abs(Hero.transform.position.x - transform.position.x);

        // Orientación enemy
        Vector3 direction = Hero.transform.position - transform.position;

        if (direction.x >= 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Si la distancia es menor o igual a la de detección y el enemigo aún no ha emergido
        if (distanceToHero <= detectionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, speed * Time.deltaTime);
        }

    }

}

