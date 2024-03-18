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
        NGHelper.instance.unlockMedal(71672);
        SceneManager.LoadScene("Game");
    }

    public void AbrePainelDeComoJogar()
    {
        NGHelper.instance.unlockMedal(71673);
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
