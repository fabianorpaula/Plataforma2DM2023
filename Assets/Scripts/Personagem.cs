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
        Animacao = GetComponent<Animator>();
        Corpo = GetComponent<Rigidbody2D>();
        
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
        velocidadeX = Input.GetAxis("Horizontal") * 3;
        Corpo.velocity = new Vector2(velocidadeX, 0);
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
}
