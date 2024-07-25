using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;

    private int digCount=2;
    private bool isDig=false;
    private void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
        boxCollider=GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        DigRock();
    }
    private void Update()
    {
        if (isDig == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                --digCount;
            }
        }
        if (digCount <= 0&&isDig==true)
        {
            float x = Random.Range(-20, 21);
            float y = Random.Range(5, 10);
            rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
            boxCollider.isTrigger = true;
            isDig = false;  
        }
    }
    public void DigRock()
    {
        digCount = Random.Range(10, 16);
        isDig= true;
    }
}
