using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public io.newgrounds.core ngio_core;

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

    void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
    }

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
	      unlockMedal(71676);
            GameManager.instance.seJogadorMorreu(pontuacao);
            FindObjectOfType<GameManager>().FimDeJogo();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cone")
        {
	      unlockMedal(71675);
            audioSource.PlayOneShot(pontoClip);
            pontuacao++;
            GameManager.instance.SetaPontuacao(pontuacao);
        }
    }
}
