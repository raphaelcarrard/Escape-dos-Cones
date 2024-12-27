using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public static PlayerScript instance;
    public float velocidade = 15f;
    public float mapaLargura = 1f;
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip pontoClip, morteClip;
    public int pontuacao;
    public bool medal1, medal2, medal3, medal4, medal5, medal6, medal7, medal8;

    void Awake()
    {
        pontuacao = 0;
        Instance();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(pontuacao >= 50 && medal1 == false){
            StartCoroutine(NGIO.UnlockMedal(77869, NgioAppConnector.instance.OnMedalUnlocked));
            medal1 = true;
        }
        if(pontuacao >= 100 && medal2 == false){
            StartCoroutine(NGIO.UnlockMedal(77870, NgioAppConnector.instance.OnMedalUnlocked));
            medal2 = true;
        }
        if(pontuacao >= 150 && medal3 == false){
            StartCoroutine(NGIO.UnlockMedal(77871, NgioAppConnector.instance.OnMedalUnlocked));
            medal3 = true;
        }
        if(pontuacao >= 200 && medal4 == false){
            StartCoroutine(NGIO.UnlockMedal(77872, NgioAppConnector.instance.OnMedalUnlocked));
            medal4 = true;
        }
        if(pontuacao >= 250 && medal5 == false){
            StartCoroutine(NGIO.UnlockMedal(77873, NgioAppConnector.instance.OnMedalUnlocked));
            medal5 = true;
        }
        if(pontuacao >= 300 && medal6 == false){
            StartCoroutine(NGIO.UnlockMedal(77874, NgioAppConnector.instance.OnMedalUnlocked));
            medal6 = true;
        }
        if(pontuacao >= 350 && medal7 == false){
            StartCoroutine(NGIO.UnlockMedal(77875, NgioAppConnector.instance.OnMedalUnlocked));
            medal7 = true;
        }
        if(pontuacao >= 400 && medal8 == false){
            StartCoroutine(NGIO.UnlockMedal(77876, NgioAppConnector.instance.OnMedalUnlocked));
            medal8 = true;
        }
    }

    void Instance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void FixedUpdate()
    {
        MoverCarro();
    }

    void MoverCarro()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * velocidade;
        Vector2 novaPosicao = rigidbody.position + Vector2.right * x;
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, -mapaLargura, mapaLargura);
        rigidbody.MovePosition(novaPosicao);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Cone")
        {
	        StartCoroutine(NGIO.UnlockMedal(71676, NgioAppConnector.instance.OnMedalUnlocked));
            GameManager.instance.seJogadorMorreu(pontuacao);
            FindObjectOfType<GameManager>().FimDeJogo();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cone")
        {
	        StartCoroutine(NGIO.UnlockMedal(71675, NgioAppConnector.instance.OnMedalUnlocked));
            audioSource.PlayOneShot(pontoClip);
            pontuacao++;
            GameManager.instance.SetaPontuacao(pontuacao);
        }
    }
}
