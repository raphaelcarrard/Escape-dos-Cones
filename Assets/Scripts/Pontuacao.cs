using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{

    public static Pontuacao instance;
    private const string MELHOR_PONTUACAO = "melhorPontuacao";

    void Awake()
    {
        JogoIniciadoPrimeiraVez();
        MakeSingleton();
    }

    void Update()
    {
        
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void JogoIniciadoPrimeiraVez()
    {
        if (!PlayerPrefs.HasKey("seJogoIniciouPrimeiraVez"))
        {
            PlayerPrefs.SetInt(MELHOR_PONTUACAO, 0);
            PlayerPrefs.SetInt("seJogoIniciouPrimeiraVez", 0);
        }
    }

    public void SetaPontuacao(int pontuacao)
    {
        PlayerPrefs.SetInt(MELHOR_PONTUACAO, pontuacao);
    }

    public int RecebePontuacao()
    {
        return PlayerPrefs.GetInt(MELHOR_PONTUACAO);
    }
}
