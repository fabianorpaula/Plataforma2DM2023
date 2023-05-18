using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    public int hp = 4;
    public bool podeTomarDano = true;
    private Animator Animacao;

    void Start()
    {
        Animacao = GetComponent<Animator>();
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
