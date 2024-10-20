using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    private int totalMonedas;

    [SerializeField]
    private TMP_Text textoMonedas;

    void Start()
    {
        Moneda.sumaMoneda += SumarMonedas;
    }

    private void SumarMonedas(int moneda)
    {
        totalMonedas += moneda;
        textoMonedas.text = totalMonedas.ToString();
    }
}
