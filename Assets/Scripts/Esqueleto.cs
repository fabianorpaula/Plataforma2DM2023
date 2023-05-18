using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    public int hp = 4;
    public bool podeTomarDano = true;
    private Animator Animacao;
    public float posInicial;
    public float posFinal;
    public bool frente = true;


    void Start()
    {
        Animacao = GetComponent<Animator>();
    }

    private void Update()
    {
        Mover();
    }

    void Mover()
    {
        if (frente == true)
        {
            //para Onde eu quero IR
            Vector2 destino = new Vector2(posFinal, transform.position.y);
            //Me deslocando
            transform.position = Vector2.MoveTowards(transform.position, destino, 0.01f);
            if(Vector2.Distance(transform.position, destino) < 0.2f)
            {
                frente = false;
            }
        }
        if (frente == false)
        {
            //para Onde eu quero IR
            Vector2 destino = new Vector2(posInicial, transform.position.y);
            //Me deslocando
            transform.position = Vector2.MoveTowards(transform.position, destino, 0.01f);
            if (Vector2.Distance(transform.position, destino) < 0.2f)
            {
                frente = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D colidiu)
    {
        if(colidiu.gameObject.tag == "Ataque")
        {
            if(podeTomarDano == true)
            {
                hp--;
                podeTomarDano = false;
                Animacao.SetTrigger("TomouDano");
                if (hp <= 0)
                {
                    Animacao.SetBool("Morto", true);
                }
            }
            
        }
    }

    public void AcabouImunidade()
    {
        podeTomarDano = true;
    }
}
