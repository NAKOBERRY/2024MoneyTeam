using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spri;

    public float speed = 5f;
    public float jumpPower = 20f;

    [SerializeField] private Vector2 inputVec;
    [SerializeField] public Vector3 bottomOffset;
    [SerializeField] public Vector2 overlabBoxSize;
    [SerializeField] public LayerMask groundLayer;
    private bool isGrounded;
    public GameObject deathPanel;
    

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spri = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        FlipSprite();
        CheckGrounded();
        Jump();
        PlayerMove();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            deathPanel.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
    }
    
    //점프
    public void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }


    //땅에 닿았는가 
    public void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + bottomOffset, overlabBoxSize, 0, groundLayer);
    }

    //스프라이트 회전 
    public void FlipSprite()
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


    //플레이어 기본 이동
    public void PlayerMove()
    {
        rigid.gravityScale = 2;
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }


}
