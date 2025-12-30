using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movimento : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerMovimento movePlayer;

    void Start()
    {
        movePlayer = GameObject.Find("Player").GetComponent<PlayerMovimento>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "BotaoEsquerda")
        {
            movePlayer.SetarParaEsquerda(true);
        }
        else
        {
            movePlayer.SetarParaEsquerda(false);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
           movePlayer.PararMovimento();
    }
}
