using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    public static MenuScript instance;
    [SerializeField]
    public Button comoJogar, fecharPainel;
    [SerializeField]
    public GameObject painel;

    public void Jogar()
    {
        StartCoroutine(NGIO.UnlockMedal(71672, NgioAppConnector.instance.OnMedalUnlocked));
        SceneManager.LoadScene("Game");
    }

    public void AbrePainelDeComoJogar()
    {
        StartCoroutine(NGIO.UnlockMedal(71673, NgioAppConnector.instance.OnMedalUnlocked));
        painel.SetActive(true);
    }

    public void FechaPainel()
    {
        painel.SetActive(false);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

}
