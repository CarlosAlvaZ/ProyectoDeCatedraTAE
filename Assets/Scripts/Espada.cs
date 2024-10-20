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
            Destroy(otro.gameObject);
        }
    }
}
