using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo sistema;
    [SerializeField] private GameObject marcos;
    [SerializeField] private TMP_Text textoDialogo;
    private bool escribiendo;
    private int indiceActual;
    // Start is called before the first frame update
    private void Awake()
    {
       
        if (sistema == null)
        {
            sistema = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void TerminarDialogo()
    {
        marcos.SetActive(false);
    }
    private void EscibirDialogo()
    {

    }
    private void SiguienteFrase()
    {

    }
    public void IniciarDialogo(DialogaSO dialogo)
    {
        marcos.SetActive(true);
    }
}
