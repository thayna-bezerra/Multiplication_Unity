using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionAnswer : MonoBehaviour
{
    public Transform destination;
    public float velocity = 3.0f;

    public GameController gc;

    private Renderer _renderer; 
    private Color32 _newColor = new Color32(144,238,144, 255);

    public Collider2D n1, n2, n3, n4;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (gc.encontrouResposta == true)
        {
            n1.enabled = false;
            n2.enabled = false;
            n3.enabled = false;
            n4.enabled = false;

            _renderer.material.color = _newColor;
            transform.position = Vector3.Lerp(transform.position, destination.position, velocity * Time.deltaTime); //Velocidade multiplicado por 0.02 segundos (deltaTime padrão)
            transform.localScale = new Vector3(0.55245f, 0.55245f, 0.55245f);
        }
    }
}
