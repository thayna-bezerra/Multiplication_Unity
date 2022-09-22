using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAnswer : MonoBehaviour
{
    public Transform destination;
    public float velocity = 3.0f;

    public GameController gc;

    private Renderer _renderer; 
    private Color32 _newColor = new Color32(144,238,144, 255);

    //public Controle controle;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (gc.encontrouResposta == true)
        {
            _renderer.material.color = _newColor;
            transform.position = Vector3.Lerp(transform.position, destination.position, velocity * Time.deltaTime); //Velocidade multiplicado por 0.02 segundos (deltaTime padrão)
            transform.localScale = new Vector3(0.75864f, 0.75864f, 0.75864f);

            StartCoroutine(espera());

            
            //transform.localScale = Vector3.Lerp(transform.localScale, newScale.Scale, velocity * Time.deltaTime);

            //this.transform.localScale = new Vector3(0.75864f, 0.75864f, 0.75864f) * Time.deltaTime;

            //scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
            //StartCoroutine(chamaPanel()); //essperar tempo ate chamar nova rodada
            //controle.jogoPausado();
        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(2f);

        //chamar nova rodada
        //panelAcertou.SetActive(true); //chamar animação de panel
    }
}
