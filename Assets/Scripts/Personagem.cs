using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    //Declarar Componentes
    private Rigidbody2D Corpo;
    private Animator Animacao;

    // Tudo que roda uma vez só no inicio
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Animacao = GetComponent<Animator>();
    }

    // Roda toda e todo tempo (FRAME)
    void Update()
    {
        Mover();
    }

    void Mover()
    {
        //Variavel de Velocidade
        float velocidadeX;
        velocidadeX = Input.GetAxis("Horizontal");
        Corpo.velocity = new Vector2(velocidadeX, 0);

        if(velocidadeX > 0)
        {
            Animacao.SetBool("Andar", true);
        }
        if(velocidadeX == 0)
        {
            Animacao.SetBool("Andar", false);
        }
    }
}
