using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer spri;

    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpPower = 10f;

    [SerializeField] public Vector2 inputVec;
    [SerializeField] public Vector3 bottomOffset;
    [SerializeField] public Vector2 overlabBoxSize;
    [SerializeField] public LayerMask groundLayer;
    public bool isGrounded;
    public bool isSwim = false;
    public bool isRide = false;



    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spri = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        Jump();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        CheckGrounded();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {           
            IsSwim();
        }
        else if (collision.gameObject.CompareTag("Riding"))
        {
            IsRide();
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
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded && !isSwim)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    //�÷��̾� �⺻ �̵�
    public void PlayerMove()
    {
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
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
        rigid.gravityScale = 0.3f;
        transform.Translate(Vector2.right * inputVec.y * speed * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * inputVec.x * speed * Time.fixedDeltaTime);
    }

    //������ �Լ�
    public void IsRide()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.right * 1 * speed * Time.fixedDeltaTime);           
        }
    }
    

}
