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
    //Sangue
    public float barraSangue = 100;
    public RectTransform imgbarraSangue;

    //Controlador
    private Controlador Control;

    // Tudo que roda uma vez s� no inicio
    void Start()
    {
        Animacao = GetComponent<Animator>();
        Corpo = GetComponent<Rigidbody2D>();
        Control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controlador>();
        
    }

    // Roda toda e todo tempo (FRAME)
    void Update()
    {
        if(Control.EstadoJogo() == true)
        {
            Mover();
            Pular();
            Ataque();
        }
        
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
    //Colis�o real, tem fisica
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Estrela")
        {
            estrelas++;
            Destroy(colisao.gameObject);
        }
    }
    //colis�o de mentirinha// passa direto
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
        if(gatilho.gameObject.tag == "PoteVida")
        {
            RecuperaVida();
            Destroy(gatilho.gameObject);
        }
    }

    void RecuperaVida()
    {
        barraSangue = barraSangue + 30;
        if(barraSangue >= 100)
        {
            barraSangue = 100;
        }
        imgbarraSangue.sizeDelta = new Vector2(barraSangue * 3, 50);
    }

    void TomouDano()
    {
        barraSangue = barraSangue - 10;
        Animacao.SetTrigger("Dano");
        if(barraSangue <= 0)
        {
            Animacao.SetBool("Morto", true);
        }
        imgbarraSangue.sizeDelta = new Vector2(barraSangue * 3, 50);
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
