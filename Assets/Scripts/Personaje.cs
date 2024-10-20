using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private Rigidbody2D rig;

    private Animator anim;

    private SpriteRenderer srpitePersonaje;

    private int vidaPersonaje = 3;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private BoxCollider2D colEspada;

    [SerializeField]
    UIManager uiManager;

    private float posColX = 1;
    private float posColY = 0;

    private bool estoyHablando = false;

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
        if (Input.GetMouseButtonDown(0) && !estoyHablando)
        {
            anim.SetTrigger("Ataca");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CausarHerida();
        }
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (!estoyHablando)
        {

            rig.velocity = new Vector2(horizontal, vertical) * velocidad;

            anim.SetFloat("Camina", Math.Abs(rig.velocity.magnitude));
        }

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

    public void ChequearSiHablo(bool hablando)
    {
        estoyHablando = hablando;
    }

    private void CausarHerida()
    {
        if (vidaPersonaje > 0)
        {
            vidaPersonaje--;
            uiManager.RestaCorazones(vidaPersonaje);
            if (vidaPersonaje == 0)
            {
                anim.SetTrigger("Muerto");
                Invoke(nameof(Morir), 1.3f);
            }
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
