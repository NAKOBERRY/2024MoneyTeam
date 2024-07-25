using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurdle : MonoBehaviour
{
    Player player; // 플레이어 객체를 참조하기 위한 변수
    Rigidbody2D rigid;

    public string TrapName;
    public int xKnockBack;
    public int yKnockBack;
    public float slowTime;
    public float slowness;

    private bool canKnockBack = true; // 넉백 가능 여부를 나타내는 변수
    public float knockBackCooldown = 2f; // 넉백 쿨다운 시간

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
                if (canKnockBack)
                {
                    KnockBack();
                }
                break;
            case "Cone":
                StartCoroutine(Slow());
                break;
        }
    }

    private void KnockBack()
    {
        if (canKnockBack)
        {
            rigid.AddForce(new Vector2(-xKnockBack, yKnockBack), ForceMode2D.Impulse);
            StartCoroutine(KnockBackCooldown());
        }
    }

    private IEnumerator KnockBackCooldown()
    {
        canKnockBack = false;
        yield return new WaitForSeconds(knockBackCooldown);
        canKnockBack = true;
    }

    private IEnumerator Slow()
    {
        player.speed /= slowness;
        yield return new WaitForSeconds(slowTime);
        player.speed *= slowness;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switchCase();
        }
    }
}
