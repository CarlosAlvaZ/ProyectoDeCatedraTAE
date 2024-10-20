using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private Rigidbody2D rig;

    private Animator anim;

    private SpriteRenderer srpitePersonaje;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private BoxCollider2D colEspada;

    private float posColX = 1;
    private float posColY = 0;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        srpitePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Ataca");
        }
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(horizontal, vertical) * velocidad;

        anim.SetFloat("Camina", Math.Abs(rig.velocity.magnitude));

        if (horizontal > 0)
        {
            colEspada.offset = new Vector2(posColX, posColY);
            srpitePersonaje.flipX = false;
        }
        else if (horizontal < 0)
        {
            colEspada.offset = new Vector2(-posColX, posColY);
            srpitePersonaje.flipX = true;
        }

    }
}
