using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public float velocidadeCones = 50f;
    [SerializeField]
    public GameObject pausaPainel, instrucaoPainel;
    [SerializeField]
    public Button menuBotao, retomarBotao;
    [SerializeField]
    public Text mostraPontuacao, melhorPontuacao, pontuacaoAtual, pausaTexto, fimDeJogoTexto, jogarTexto, instrucaoTexto;


    void Awake()
    {
        Instance();
    }

    void Start()
    {
        Time.timeScale = 0f;
        pausaPainel.SetActive(true);
        instrucaoPainel.SetActive(true);
        instrucaoTexto.gameObject.SetActive(true);
        jogarTexto.gameObject.SetActive(true);
        melhorPontuacao.text = "" + Pontuacao.instance.RecebePontuacao();
    }

    void Instance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void FimDeJogo()
    {
        StartCoroutine(ReiniciaJogo());
    }

    IEnumerator ReiniciaJogo()
    {
        Time.timeScale = 1f / velocidadeCones;
        Time.fixedDeltaTime = Time.fixedDeltaTime / velocidadeCones;
        yield return new WaitForSeconds(1f / velocidadeCones);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * velocidadeCones;
        Jogar();
    }

    public void Jogar()
    {
        pausaPainel.SetActive(false);
        instrucaoPainel.SetActive(false);
        instrucaoTexto.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void PausaJogo()
    {
	    StartCoroutine(NGIO.UnlockMedal(71677, NgioAppConnector.instance.OnMedalUnlocked));
        pausaPainel.SetActive(true);
        instrucaoPainel.SetActive(false);
        instrucaoTexto.gameObject.SetActive(false);
        jogarTexto.gameObject.SetActive(false);
        fimDeJogoTexto.gameObject.SetActive(false);
        pausaTexto.gameObject.SetActive(true);
        pontuacaoAtual.text = "" + PlayerScript.instance.pontuacao;
        melhorPontuacao.text = "" + Pontuacao.instance.RecebePontuacao();
        Time.timeScale = 0f;
    }

    public void RetornarJogo()
    {
        pausaPainel.SetActive(false);
        instrucaoPainel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IrAoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetaPontuacao(int pontuacao)
    {
        pontuacaoAtual.text = "" + pontuacao;
        mostraPontuacao.text = "" + pontuacao;
    }

    public void seJogadorMorreu(int pontuacao)
    {
        StartCoroutine(NGIO.PostScore(13586, pontuacao, null, NgioAppConnector.instance.OnScorePosted));
        pausaPainel.SetActive(true);
        instrucaoPainel.SetActive(false);
        instrucaoTexto.gameObject.SetActive(false);
        fimDeJogoTexto.gameObject.SetActive(true);
        jogarTexto.gameObject.SetActive(false);
        pausaTexto.gameObject.SetActive(false);
        pontuacaoAtual.text = "" + PlayerScript.instance.pontuacao;
        melhorPontuacao.text = "" + pontuacao;
        if (pontuacao > Pontuacao.instance.RecebePontuacao())
        {
            Pontuacao.instance.SetaPontuacao(pontuacao);
        }
        melhorPontuacao.text = "" + Pontuacao.instance.RecebePontuacao();
    }
}
