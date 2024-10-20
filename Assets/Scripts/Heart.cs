using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public delegate void SumaCorazones(int corazones);
    public static event SumaCorazones sumaCorazones;

    [SerializeField]
    private int cantidadCorazones;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaCorazones != null)
            {
                SumarCorazones();
                Destroy(this.gameObject);
            }
        }
    }

    private void SumarCorazones()
    {
        sumaCorazones(cantidadCorazones);
    }
}
