using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    [Header("Variáveis de erros e acertos")]
    public int totalAcertos;
    public int totalErros;
    public int totalContas;

    private void Update()
    {
        totalContas = totalAcertos + totalErros;
    }

    void OnMouseDown()
    {
        if(gameObject.tag == "Resposta")
        {
            totalErros++;
            Debug.Log("Essa é a resposta");
        }

        if(gameObject.tag == "Errado")
        {
            totalErros++;
            Debug.Log("Resposta ERRADA");
        }
    }
}
