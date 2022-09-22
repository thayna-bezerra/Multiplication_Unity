using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    public GameController gc;

    void OnMouseDown()
    {
        if(gameObject.tag == "Resposta")
        {
            gc.totalAcertos++;
            gc.encontrouResposta = true;
            Debug.Log("Essa é a resposta");
        }
       
        if(gameObject.tag == "Errado")
        {
            gc.totalErros++;
            gc.respostaErrada = true;
            Debug.Log("Resposta ERRADA");
        }
    }
}
