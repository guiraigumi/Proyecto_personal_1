using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    //Variable para tocar el suelo
    public bool isGrounded;
    //Variable para almacenar el input de movimiento
    public Animator _animator;
    private float dirx;
    //Declaramos variables necesarias sprite renderer y rigid body
    public SpriteRenderer renderer;
    Rigidbody2D _rBody;

    void Awake()
    {
        //Asignamos los componentes a las variables
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    //Flip del sprite
    {
        dirx = Input.GetAxisRaw("Horizontal");

        Debug.Log(dirx);

        if (dirx == -1)
        {
            renderer.flipX = true;
            _animator.SetBool("Run", true);
        }

        else if (dirx == 1)
        {
            renderer.flipX = false;
            _animator.SetBool("Run", true);
        }

        else
        {
            _animator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jump", true);
        }

    }

    void FixedUpdate()
    //Mover Mario con velocidad
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }
}