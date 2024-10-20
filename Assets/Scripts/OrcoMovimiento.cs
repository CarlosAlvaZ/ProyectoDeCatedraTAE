using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcoMovimiento : MonoBehaviour
{
    private Rigidbody2D rig;

    private Animator anim;

    private SpriteRenderer srpitePersonaje;

    private int vidaPersonaje = 3;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private BoxCollider2D colEspada;

    private float posColX = 0.5f;
    private float posColY = 0;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        srpitePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0)
        {
            anim.SetFloat("Camina", Math.Abs(rig.velocity.magnitude));
            colEspada.offset = new Vector2(posColX, posColY);
            srpitePersonaje.flipX = false;
        }
        else if (horizontal < 0)
        {
            anim.SetFloat("Camina", Math.Abs(rig.velocity.magnitude));
            colEspada.offset = new Vector2(-posColX, posColY);
            srpitePersonaje.flipX = true;
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
