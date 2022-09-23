using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    public GameController gc;

    private void Start()
    {
    }

    void OnMouseDown()
    {
        if(gameObject.tag == "Resposta")
        {
            gc.totalAcertos++;
            gc.encontrouResposta = true;

            PlayerPrefs.SetInt("Acertos", gc.totalAcertos);
        }
       
        if(gameObject.tag == "Errado/1")
        {
            gc.totalErros++;
            gc.respostaErrada = true;

            gc.num3.Play("errorAnim");
            
            PlayerPrefs.SetInt("Erros", gc.totalErros);
        }

        if(gameObject.tag == "Errado/2")
        {
            gc.totalErros++;
            gc.respostaErrada = true;

            gc.num4.Play("errorAnim2");

            PlayerPrefs.SetInt("Erros", gc.totalErros);
        }

        if(gameObject.tag == "Errado/3")
        {
            gc.totalErros++;
            gc.respostaErrada = true;

            gc.num5.Play("errorAnim3");

            PlayerPrefs.SetInt("Erros", gc.totalErros);
        }
    }
}
