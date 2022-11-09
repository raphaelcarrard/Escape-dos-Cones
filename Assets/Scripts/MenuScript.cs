using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    public io.newgrounds.core ngio_core;

    public static MenuScript instance;
    [SerializeField]
    public Button comoJogar, fecharPainel;
    [SerializeField]
    public GameObject painel;

    void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
    }

    public void Jogar()
    {
        unlockMedal(71672);
        SceneManager.LoadScene("Game");
    }

    public void AbrePainelDeComoJogar()
    {
        unlockMedal(71673);
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
