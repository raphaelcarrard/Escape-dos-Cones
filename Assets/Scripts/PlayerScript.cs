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
            NGHelper.instance.unlockMedal(77869);
            medal1 = true;
        }
        if(pontuacao >= 100 && medal2 == false){
            NGHelper.instance.unlockMedal(77870);
            medal2 = true;
        }
        if(pontuacao >= 150 && medal3 == false){
            NGHelper.instance.unlockMedal(77871);
            medal3 = true;
        }
        if(pontuacao >= 200 && medal4 == false){
            NGHelper.instance.unlockMedal(77872);
            medal4 = true;
        }
        if(pontuacao >= 250 && medal5 == false){
            NGHelper.instance.unlockMedal(77873);
            medal5 = true;
        }
        if(pontuacao >= 300 && medal6 == false){
            NGHelper.instance.unlockMedal(77874);
            medal6 = true;
        }
        if(pontuacao >= 350 && medal7 == false){
            NGHelper.instance.unlockMedal(77875);
            medal7 = true;
        }
        if(pontuacao >= 400 && medal8 == false){
            NGHelper.instance.unlockMedal(77876);
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
	        NGHelper.instance.unlockMedal(71676);
            GameManager.instance.seJogadorMorreu(pontuacao);
            FindObjectOfType<GameManager>().FimDeJogo();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cone")
        {
	        NGHelper.instance.unlockMedal(71675);
            audioSource.PlayOneShot(pontoClip);
            pontuacao++;
            GameManager.instance.SetaPontuacao(pontuacao);
        }
    }
}
