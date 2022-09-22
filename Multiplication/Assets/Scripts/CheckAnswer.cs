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
        }
       
        if(gameObject.tag == "Errado/1")
        {
            gc.totalErros++;
            gc.respostaErrada = true;

            gc.num3.Play("errorAnim");
        }

        if(gameObject.tag == "Errado/2")
        {
            gc.totalErros++;
            gc.respostaErrada = true;

            gc.num4.Play("errorAnim2");
        }

        if(gameObject.tag == "Errado/3")
        {
            gc.totalErros++;
            gc.respostaErrada = true;

            gc.num5.Play("errorAnim3");
        }
    }
}
