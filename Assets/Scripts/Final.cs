using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject Hero;
    public float detectionDistance;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
