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
    private string playerStats = "run";


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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerStats = "run";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerStats = "swim";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerStats = "ride";
        }
        PlayerStats(playerStats);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            playerStats = "swim";
        }
        else if (collision.gameObject.CompareTag("RIde"))
        {
            playerStats = "ride";
        }
        else if (collision.gameObject.CompareTag("Run"))
        {
            playerStats = "run";
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
    }

    private void PlayerStats(string playerStats)
    {

        switch (playerStats)
        {
            case "run":
                PlayerMove();
                Jump();
                break;

            case "swim":
                IsSwim();
                break;

            case "ride":
                IsRide();
                Jump();
                break;
        }
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

    //수영 함수
    public void IsSwim()
    {
        rigid.gravityScale = 0;
        transform.Translate(Vector2.up * inputVec.y * speed * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }

    //자전거 함수
    public void IsRide()
    {
        var rideSpeed = speed + 3f;
        rigid.gravityScale = 2;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * inputVec.x * rideSpeed * Time.fixedDeltaTime);
        }     
    }

    //플레이어 기본 이동
    public void PlayerMove()
    {
        rigid.gravityScale = 2;
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }
}
