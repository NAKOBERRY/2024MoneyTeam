using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Rigidbody2D rigid;
    
    private int digCount = 5;
    public bool isDig = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (digCount <= 0 && isDig)
        {
            float x = Random.Range(-20, 21);
            float y = Random.Range(5, 10);
            rigid.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
            isDig = false;          
            GameManager.instance.ClearMinigame();
        }
        if (isDig)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                --digCount;
            }
        }
    }    
}
