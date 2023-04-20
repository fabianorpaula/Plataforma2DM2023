using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public Animator Anim;
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    void Update()
    {

        float velX = Input.GetAxis("Horizontal")*4;
        Corpo.velocity = new Vector2(velX, 0);

        if(velX == 0)
        {
            Anim.SetBool("Correndo", false);
        }
        else
        {
            Anim.SetBool("Correndo", true);
        }

        if(velX > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(velX < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }
}
