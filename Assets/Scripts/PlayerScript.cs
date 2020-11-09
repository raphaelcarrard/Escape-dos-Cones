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

    void Instance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
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
            GameManager.instance.seJogadorMorreu(pontuacao);
            FindObjectOfType<GameManager>().FimDeJogo();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cone")
        {
            audioSource.PlayOneShot(pontoClip);
            pontuacao++;
            GameManager.instance.SetaPontuacao(pontuacao);
        }
    }
}
