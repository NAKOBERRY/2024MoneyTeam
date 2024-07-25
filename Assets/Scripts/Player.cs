using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spri;

    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpPower = 10f;

    [SerializeField] private Vector2 inputVec;
    [SerializeField] public Vector3 bottomOffset;
    [SerializeField] public Vector2 overlabBoxSize;
    [SerializeField] public LayerMask groundLayer;
    private bool isGrounded;
    private bool isSwim = false;
    private bool isRide = false;



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

        PlayerMove();

    }

    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
    }

    //점프
    public void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded && !isSwim)
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

    //수영 함수
    public void IsSwim()
    {
        rigid.gravityScale = 0.3f;
        transform.Translate(Vector2.right * inputVec.y * speed * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }

    //자전거 함수
    public void IsRide()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.right * 1 * speed * Time.fixedDeltaTime);
            Jump();
        }
    }

    //플레이어 기본 이동
    public void PlayerMove()
    {
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
        Jump();
    }

}
