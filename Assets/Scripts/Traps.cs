using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player; // �÷��̾� ��ü�� �����ϱ� ���� ����
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

    }
    public void switchCase()
    {
        switch (TrapName)
        {
            case "Hurdle":
                KnockBack();
                break;
        }
    }

    public void KnockBack()
    {
        rigid.AddForce(new Vector2(-xKnockBack, yKnockBack), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            KnockBack();

        }


        switchCase();
    }

}

