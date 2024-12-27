using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{

    public float velocidade = 15f;
    public float maximo = 4f;
    private Rigidbody2D rigidbody;
    private bool moveEsquerda, moveDireita;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveEsquerda)
        {
            MoveEsquerda();
        }
        if (moveDireita)
        {
            MoveDireita();
        }
    }

    public void SetarParaEsquerda(bool moveEsquerda)
    {
        this.moveEsquerda = moveEsquerda;
        this.moveDireita = !moveEsquerda;
    }

    public void PararMovimento()
    {
        moveEsquerda = moveDireita = false;
    }

    void MoveEsquerda()
    {
        float forcaX = 0f;
        float vel = Mathf.Abs(rigidbody.linearVelocity.x);
        if (vel < maximo)
        {
            forcaX = -velocidade;
        }
        Vector3 temp = transform.localScale;
        transform.localScale = temp;
        rigidbody.AddForce(new Vector2(forcaX, 0));
    }

    void MoveDireita()
    {
        float forcaX = 0f;
        float vel = Mathf.Abs(rigidbody.linearVelocity.x);
        if (vel < maximo)
        {
            forcaX = velocidade;
        }
        Vector3 temp = transform.localScale;
        transform.localScale = temp;
        rigidbody.AddForce(new Vector2(forcaX, 0));
    }
}
