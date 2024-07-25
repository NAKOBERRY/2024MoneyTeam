using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKeyDown(KeyCode.V))
            KnockBack();
        // �����̽��ٰ� ������ �� stunTime�� 0.1�� ����
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
