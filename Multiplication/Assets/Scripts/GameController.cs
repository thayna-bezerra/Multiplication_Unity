using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Variáveis da MULTIPLICAÇÃO")]
    public int n1; //Números que deverão ser gerados aleatoriamente
    public int n2;
    public int resultadoMult; //Resultado da Mult dado os numeros aleatorios

    public bool encontrouResposta = false;
    public bool respostaErrada = false;

    [Space(5)]

    [Header("Imagens correspondentes a cada número")]
    public SpriteRenderer imgN1;
    public SpriteRenderer imgN2;
    public SpriteRenderer imgResposta;
    public SpriteRenderer imgN3, imgN4, imgN5; //Imagens para as respostas incorretas

    public Animator num3, num4, num5;

    [Space(5)]

    [Header("Lista com todas as sprites de NÚMEROS")]
    public List<Sprite> numeros = new List<Sprite>();

    [Space(5)]

    [Header("Opções de Resultado ERRADO")]
    public int limiteNum = 3; //Limite para sortear até 3 números
    public int valorSorteado; //Último valor sorteado
    public int[] respostasErradas = new int[3]; //Guardar os 3 números gerados e verificar um a um dentro da lista

    [Space(5)]

    [Header("Variáveis de erros e acertos")]
    public int totalAcertos;
    public int totalErros;
    public int totalContas;

    public Text textAcertos;
    public Text textErros;

    [Space(5)]

    [Header("Contador de Tempo")]
    public Text secondsTxt;
    public Text minutesTxt;

    public int limiteDosSegundos;
    public float seconds;
    public int minutes;

    public bool stopTime = false;

    [Space(5)]

    [Header("Panel Final")]

    public GameObject panelFinal;
    public Text acertosPanel;
    public Text errosPanel;
    public Text minutesPanel;
    public Text secondsPanel;

    private void Start()
    {
        panelFinal.SetActive(false);

        SortearNumeros();
        MultiplicarNumeros(n1, n2);

        GeradorDeRespostasErradas();

        imgN3.GetComponent<SpriteRenderer>().sprite = numeros[respostasErradas[0]];
        imgN4.GetComponent<SpriteRenderer>().sprite = numeros[respostasErradas[1]];
        imgN5.GetComponent<SpriteRenderer>().sprite = numeros[respostasErradas[2]];
    }

    private void FixedUpdate()
    {
        if(stopTime == false)
        {
            ContadorDeTempo();
        }
    }

    private void Awake()
    {
        minutes = PlayerPrefs.GetInt("MinutesTime");
        seconds = PlayerPrefs.GetFloat("SecondsTime");
    }

    private void Update()
    {
        totalAcertos = PlayerPrefs.GetInt("Acertos");
        totalErros = PlayerPrefs.GetInt("Erros");

        textAcertos.text = totalAcertos.ToString();
        textErros.text = totalErros.ToString();

        totalContas = totalAcertos + totalErros;

        if (encontrouResposta == true && totalContas<=10)
            StartCoroutine(ChamarNovaRodada());

        else if(totalContas>=10)
            ChamaPanel();

    }

    void SortearNumeros()
    {
        n1 = Random.Range(0, 11); //Gerar número aleatório e guardar na variável
        n2 = Random.Range(0, 11);

        imgN1.GetComponent<SpriteRenderer>().sprite = numeros[n1]; //Buscar número gerado pelo index dentro da lista
        imgN2.GetComponent<SpriteRenderer>().sprite = numeros[n2]; //Vai pegar a imagem correspondente ao número gerado de acordo com o index
    }

    void MultiplicarNumeros(int N1, int N2)
    {
        resultadoMult = N1 * N2;
        imgResposta.GetComponent<SpriteRenderer>().sprite = numeros[resultadoMult];
    }

    void GeradorDeRespostasErradas()
    {
        for (int i = 0; i <= limiteNum - 1; i++)
        {
        Inicio:
            valorSorteado = Random.Range(0, 50);

            for (int x = 0; x <= limiteNum - 1; x++)
            {
                if (valorSorteado == resultadoMult || respostasErradas[x] == valorSorteado) //Se o valor que foi sorteado for igual ao resultado da mult OU se o número sorteado é igual a algum elemento da array, voltar a ref e sortear novo numero
                {
                    goto Inicio;
                }

            }

            respostasErradas[i] = valorSorteado;
        }
    }

    IEnumerator ChamarNovaRodada()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("SampleScene");
    }

    void ContadorDeTempo()
    {
        secondsTxt.text = seconds.ToString("00");
        minutesTxt.text = minutes.ToString("00");

        seconds += Time.deltaTime;
        if (seconds >= limiteDosSegundos)
        {
            minutes++;
            seconds = 0 + 1;
        }

        PlayerPrefs.SetInt("MinutesTime", minutes);
        PlayerPrefs.SetFloat("SecondsTime", seconds);
    }

    void ChamaPanel()
    {
        stopTime = true;
        panelFinal.SetActive(true);

        acertosPanel.text = totalAcertos.ToString();
        errosPanel.text = totalErros.ToString();

        secondsPanel.text = seconds.ToString("00");
        minutesPanel.text = minutes.ToString("00");
    }

}
