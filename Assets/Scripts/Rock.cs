using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    private Animator animator;
    public GameManager gameManager;
    

    private int digCount=2;
    private bool isDig=false;
    private void Awake()
    {
        animator= GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        boxCollider=GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (digCount <= 0&&isDig==true)
        {
            float x = Random.Range(-20, 21);
            float y = Random.Range(5, 10);
            rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
            boxCollider.isTrigger = true;
            isDig = false;
            gameManager.ClearMinigame();
        }
        if (isDig == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                --digCount;
            }
        }
    }
    public void DigRock()
    {
        digCount = Random.Range(7, 12);
        isDig= true;
    }
}
