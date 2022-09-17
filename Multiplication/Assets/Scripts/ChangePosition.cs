using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    [Header("Guardar POSICOES e NUMEROS")]
    [Space(5)]

    public List<Vector2> pontoPos = new List<Vector2>();//Objeto vazio com o componente transform correspondente a sua posição
    public List<GameObject> numerosParaNovaPos = new List<GameObject>();//Numeros que serão transferidos entre essas posicoes

    [Header("Armazenar POSICOES e NUMEROS já sorteados")]
    [Space(5)]

    //Lista para salvar todas as posições que ja foram sorteadas;
    public List<Vector2> posicoesSorteadas = new List<Vector2>();
    public List<GameObject> spritesSorteadas = new List<GameObject>();

    private void Start()
    {
        chamarNovasPos();
    }

    void chamarNovasPos()
    {
        for (int i = 0; i < 4; i++)
        {
            gerarNovasPos();
            gerarNovasSpritesNums();
        }

        spritesSorteadas[0].transform.position = posicoesSorteadas[0];
        spritesSorteadas[1].transform.position = posicoesSorteadas[1];
        spritesSorteadas[2].transform.position = posicoesSorteadas[2];
        spritesSorteadas[3].transform.position = posicoesSorteadas[3];
    }

    void gerarNovasPos()
    {
        int randomIndex = Random.Range(0, pontoPos.Count);
        Vector2 randomPos = pontoPos[randomIndex];

        if (posicoesSorteadas.Contains(randomPos))
            gerarNovasPos();
        else
            posicoesSorteadas.Add(randomPos);
    }

    void gerarNovasSpritesNums()
    {
        int randomNums = Random.Range(0, numerosParaNovaPos.Count);
        GameObject randomNum = numerosParaNovaPos[randomNums];

        if (spritesSorteadas.Contains(randomNum))
            gerarNovasSpritesNums();
        else
            spritesSorteadas.Add(randomNum);
    }
}