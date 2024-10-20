using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextos : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)]
    private string[] arrayTextos;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Personaje personaje;

    private int indice;

    private void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player").GetComponent<Personaje>();
    }

    private void OnMouseDown()
    {
        float distancia = Vector2.Distance(this.gameObject.transform.position, personaje.transform.position);
        if (distancia <= 2)
        {
            uiManager.ActivaDesactivaCajaTextos(true);
            personaje.ChequearSiHablo(true);
            ActivaCartel();
        }
    }

    void ActivaCartel()
    {
        if (indice < arrayTextos.Length)
        {
            uiManager.MostrarTextos(arrayTextos[indice]);
            indice++;
        }
        else
        {
            uiManager.ActivaDesactivaCajaTextos(false);
            personaje.ChequearSiHablo(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
