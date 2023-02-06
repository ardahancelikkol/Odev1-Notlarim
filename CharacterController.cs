using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 400f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool Grounded;
    private bool Started;
    private bool Jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Grounded = true;
        //started = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Started && Grounded)
            {
                _animator.SetTrigger("Jump");
                Grounded = false;
                Jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted", true);
                Started = true;
            }
        }

        _animator.SetBool("Grounded", Grounded);
    }   

    private void FixedUpdate()
    {
        if (Started)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }
        
        if (Jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            Jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
    {   }
            Grounded = true;
        }
}
