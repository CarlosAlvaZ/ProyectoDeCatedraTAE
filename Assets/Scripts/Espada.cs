using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private BoxCollider2D colEspada;

    private void Awake()
    {
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Orco"))
        {
            Animator anim = otro.gameObject.GetComponentInChildren<Animator>();
            anim.SetTrigger("Muere");
            Destroy(otro.gameObject, 1f);
        }
        else if (otro.CompareTag("Cofre"))
        {
            SpawnHeart sp = otro.gameObject.GetComponent<SpawnHeart>();
            sp.DestroyChest();
        }
    }
}
