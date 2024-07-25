using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player; // 플레이어 객체를 참조하기 위한 변수
    Rigidbody2D rigid;

    public string TrapName;
    public int xKnockBack;
    public int yKnockBack;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        rigid = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            KnockBack();
        // 스페이스바가 눌렸을 때 stunTime을 0.1초 줄임
    }

    public void KnockBack()
    {
        rigid.AddForce(new Vector2(-xKnockBack, yKnockBack), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KnockBack();

        }

    }
}
