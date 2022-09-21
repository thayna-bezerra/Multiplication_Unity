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
            Debug.Log("Essa é a resposta");
        }
       
        if(gameObject.tag == "Errado")
        {
            gc.totalErros++;
            Debug.Log("Resposta ERRADA");
        }
    }
}
