using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    //Declarar Componentes
    private Rigidbody2D Corpo;
    private Animator Animacao;
    public GameObject MeuAtk;

    //Variaveis
    public bool noChao = false;
    public int qtdPulos = 2;
    public int estrelas = 0;
    public float barraSangue = 100;

    // Tudo que roda uma vez só no inicio
    void Start()
    {
        Animacao = GetComponent<Animator>();
        Corpo = GetComponent<Rigidbody2D>();
        
    }

    // Roda toda e todo tempo (FRAME)
    void Update()
    {
        Mover();
        Pular();
        Ataque();
    }

    void Ataque()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Animacao.SetTrigger("Ataque");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Animacao.SetTrigger("Ataque");
        }
    }

    void Mover()
    {
        //Variavel de Velocidade
        float velocidadeX;
        velocidadeX = Input.GetAxis("Horizontal") * 3;
        Corpo.velocity = new Vector2(velocidadeX, Corpo.velocity.y);
        //Animacao
        if(Mathf.Abs(velocidadeX) > 0)
        {
            Animacao.SetBool("Andar", true);
            if (velocidadeX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (velocidadeX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if(velocidadeX == 0)
        {
            Animacao.SetBool("Andar", false);
        }
    }


    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
             //pulo unico
            if(noChao == true)
            {
                Corpo.AddForce(Vector2.up * 300);
                noChao = false;
            }/*
            //Pulo mutiplo
            if(qtdPulos > 0)
            {
                Corpo.AddForce(Vector2.up * 300);
                qtdPulos--;
            }*/
            
            
        }
    }
    //Colisão real, tem fisica
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Estrela")
        {
            estrelas++;
            Destroy(colisao.gameObject);
        }
    }
    //colisão de mentirinha// passa direto
    private void OnTriggerEnter2D(Collider2D gatilho)
    {
        if(gatilho.gameObject.tag == "Chao")
        {
            noChao = true;
            qtdPulos = 2;
        }

        if (gatilho.gameObject.tag == "Estrela")
        {
            estrelas++;
            Destroy(gatilho.gameObject);
        }
        if (gatilho.gameObject.tag == "AtaqueInimigo")
        {
            TomouDano();
        }
    }

    void TomouDano()
    {
        barraSangue = barraSangue - 10;
        Animacao.SetTrigger("Dano");
        if(barraSangue <= 0)
        {
            Animacao.SetBool("Morto", true);
        }
    }

    public void Morreu()
    {
        Animacao.SetBool("Vivo", false);
    }

    public void AtivaAtk()
    {
        MeuAtk.SetActive(true);
    }

    public void DesativaAtk()
    {
        MeuAtk.SetActive(false);
    }

}
