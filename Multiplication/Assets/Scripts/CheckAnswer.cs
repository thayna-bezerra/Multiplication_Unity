using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    void OnMouseDown()
    {
        if(this.gameObject.tag == "Resposta")
        {
            Debug.Log("Essa é a resposta");
        }

        if(this.gameObject.tag == "Errado")
        {
            Debug.Log("Resposta ERRADA");
        }
    }
}
