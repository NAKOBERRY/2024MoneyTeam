using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rock rock;
    private Rigidbody2D rigid;

    public float speed = 5f;
    public float jumpPower = 20f;

    [SerializeField] public Vector3 bottomOffset;
    [SerializeField] public Vector2 overlabBoxSize;
    [SerializeField] public LayerMask groundLayer;
    private bool isGrounded;
    public GameObject deathPanel;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {            
        CheckGrounded();      
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }  

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + bottomOffset, overlabBoxSize);
    }
    
    /*Á¡ÇÁ
    public void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }*/


    //¶¥¿¡ ´ê¾Ò´Â°¡  
    public void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + bottomOffset, overlabBoxSize, 0, groundLayer);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            rock.DigRock();
        }
    }
}
