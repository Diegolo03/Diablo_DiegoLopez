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
    private DialogaSO dialogoActual;
    private int indiceFraseActual;
    [SerializeField] private Transform npcCamera;
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
    public void IniciarDialogo(DialogaSO dialogo,Transform camaraPoint)
    {
        npcCamera.SetPositionAndRotation(camaraPoint.position,camaraPoint.transform.rotation);
        Time.timeScale = 0f;

        dialogoActual = dialogo;
        marcos.SetActive(true);
        StartCoroutine(EscibirFrase());
    }
    private IEnumerator EscibirFrase()
    {
        escribiendo = true;
        textoDialogo.text = "";

        char[] fraseDeletreada = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseDeletreada)
        {
            
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.delay);
        }
        escribiendo = false;
    }
    public void SiguienteFrase()
    {

        if (escribiendo)
        {
            CompletarFrase();
            
        }
        else
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoActual.frases.Length)
            {

                StartCoroutine(EscibirFrase());

            }
            else
            {
                TerminarDialogo();
            }
        }
        
       
    }
    public void CompletarFrase()
    {
       StopAllCoroutines();
       textoDialogo.text = dialogoActual.frases[indiceFraseActual];
       escribiendo = false;
    }
    private void TerminarDialogo()
    {
        
        marcos.SetActive(false);
        StopAllCoroutines();
        indiceFraseActual = 0;
        escribiendo = false;
        dialogoActual = null;
        Time.timeScale = 1f;
    }
}
