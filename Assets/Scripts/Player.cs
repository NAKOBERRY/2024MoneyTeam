using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spri;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 10f;

    [SerializeField] private Vector2 inputVec;
    [SerializeField] private Vector3 bottomOffset;
    [SerializeField] private Vector2 overlabBoxSize;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;




    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spri = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        Jump();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        CheckGrounded();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void PlayerMove()
    {
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + bottomOffset, overlabBoxSize, 0, groundLayer);
    }


    private void FlipSprite()
    {
        if (inputVec.x < 0)
        {
            spri.flipX = true;
        }
        else if (inputVec.x > 0)
        {
            spri.flipX = false;
        }
    }

}
