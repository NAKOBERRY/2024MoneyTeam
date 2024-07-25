using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spri;

    public float speed = 5f;
    public float jumpPower = 10f;

    [SerializeField] private Vector2 inputVec;
    [SerializeField] public Vector3 bottomOffset;
    [SerializeField] public Vector2 overlabBoxSize;
    [SerializeField] public LayerMask groundLayer;
    private bool isGrounded;  
    private string playerStats = "swim";


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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerStats = "run";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerStats = "swim";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerStats = "ride";
        }
        PlayerStats(playerStats);
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
    }

    //����
    public void Jump()
    {
        CheckGrounded();
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }


    //���� ��Ҵ°� 
    public void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + bottomOffset, overlabBoxSize, 0, groundLayer);
    }

    //��������Ʈ ȸ�� 
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

    //���� �Լ�
    public void IsSwim()
    {
        rigid.gravityScale = 0;
        transform.Translate(Vector2.up * inputVec.y * speed * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }
     
    //������ �Լ�
    public void IsRide()
    {
        var rideSpeed = speed + 3f;
        rigid.gravityScale = 1;
        if (Input.GetKeyDown(KeyCode.A))
        {          
            transform.Translate(Vector2.right * 1 * rideSpeed * Time.fixedDeltaTime);
        }
    }

    //�÷��̾� �⺻ �̵�
    public void PlayerMove()
    {
        rigid.gravityScale = 1;
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);        
    }
}
